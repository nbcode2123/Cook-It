using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private GameObject _player;
    private Action OnMove;
    public Action OnEndMove;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnMove?.Invoke();

    }
    public void SubscribeOnEndMove(Action action)
    {
        OnEndMove -= action;
        OnEndMove += action;
    }
    public void UnSubscribeOnEndMove(Action action)
    {
        OnEndMove -= action;
    }
    public void SetPlayer(GameObject player)
    {
        _player = player;
        _navMeshAgent = _player.GetComponent<NavMeshAgent>();

    }
    public void MovePlayer(Vector3 position)
    {
        _navMeshAgent.isStopped = true;

        _navMeshAgent.ResetPath();

        _navMeshAgent.SetDestination(position);

        _navMeshAgent.isStopped = false;
        OnMove += CheckPos;

        Quaternion targetPos = Quaternion.LookRotation(position);

        _player.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetPos, 100f);

    }
    private void CheckPos()
    {
        if (!_navMeshAgent.pathPending)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    Debug.Log("Đến đích");
                    ObserverManager.Notify(ObserverEvent.EndMoveNavigation);
                    OnMove -= CheckPos;
                }
            }
        }

    }
}
