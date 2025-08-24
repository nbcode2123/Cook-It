using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;


public class RaycastController : MonoBehaviour
{
    public GameObject _player;
    [SerializeField] private ITriggerObject _currentTriggerObject;
    [SerializeField] private GameObject _currentColliderDetected;

    private Vector3 test;
    public void SetPlayer(GameObject obj)
    {
        _player = obj;
    }


    private void CheckHit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Floor", "TriggerObject")))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Floor"))
                {
                    ObserverManager.Notify(ObserverEvent.RayCastDetectPoint, hit.point);

                }
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("TriggerObject"))
                {
                    _currentColliderDetected = hit.collider.gameObject;
                    if (_currentColliderDetected.gameObject.GetComponent<ITriggerObject>() != null)
                    {
                        _currentTriggerObject = _currentColliderDetected.gameObject.GetComponent<ITriggerObject>();
                        ObserverManager.Notify(ObserverEvent.RayCastDetectObj, hit.collider.gameObject);
                        ObserverManager.AddListener(ObserverEvent.EndMoveNavigation, _currentTriggerObject.TriggerEvent);


                    }
                    Vector3 playerPos = new Vector3(_player.transform.position.x, 0, _player.transform.position.z);
                    Vector3 hitPos = new Vector3(hit.collider.gameObject.transform.position.x, 0, hit.collider.gameObject.transform.position.z);

                    Vector3 direction = (playerPos - hitPos).normalized;

                    NavMeshHit navMeshHit;
                    test = hit.point + direction;
                    if (NavMesh.SamplePosition(hit.point + direction, out navMeshHit, 1.5f, NavMesh.AllAreas))
                    {
                        ObserverManager.Notify(ObserverEvent.RayCastDetectPoint, navMeshHit.position);






                    }




                }
            }
        }
    }
    private void Update()
    {
        CheckHit();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(test, 1.5f);
    }


}
