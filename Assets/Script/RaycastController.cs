using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;


public class RaycastController : MonoBehaviour
{
    public GameObject _player;
    private event Action<Vector3> OnDetectPoint = delegate { };
    private event Action<GameObject> OnDetectObject = delegate { };

    private Vector3 test;
    public void SetPlayer(GameObject obj)
    {
        _player = obj;
    }
    public void SubscribeDetectPoint(Action<Vector3> action)
    {
        OnDetectPoint -= action;
        OnDetectPoint += action;
    }


    public void UnSubscribeDetectPoint(Action<Vector3> action)
    {
        OnDetectPoint -= action;
    }
    public void SubscribeDetectObj(Action<GameObject> action)
    {
        OnDetectObject -= action;
        OnDetectObject += action;
    }


    public void UnSubscribeDetectObj(Action<GameObject> action)
    {
        OnDetectObject -= action;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Floor", "TriggerObject")))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Floor"))
                {
                    OnDetectPoint?.Invoke(hit.point);
                }
                else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("TriggerObject"))
                {
                    OnDetectObject?.Invoke(hit.collider.gameObject);
                    Vector3 playerPos = new Vector3(_player.transform.position.x, 0, _player.transform.position.z);
                    Vector3 hitPos = new Vector3(hit.collider.gameObject.transform.position.x, 0, hit.collider.gameObject.transform.position.z);

                    Vector3 direction = (playerPos - hitPos).normalized;

                    NavMeshHit navMeshHit;
                    test = hit.point + direction;
                    if (NavMesh.SamplePosition(hit.point + direction, out navMeshHit, 1.5f, NavMesh.AllAreas))
                    {
                        OnDetectPoint?.Invoke(navMeshHit.position);



                    }




                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(test, 1.5f);
    }


}
