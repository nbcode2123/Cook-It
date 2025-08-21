using System;

using UnityEngine;


public class RaycastController : MonoBehaviour
{
    public GameObject _player;
    private event Action<Vector3> OnDetectPoint = delegate { };
    public void Subscribe(Action<Vector3> action)
    {
        OnDetectPoint -= action;
        OnDetectPoint += action;
    }


    public void UnSubscribe(Action<Vector3> action)
    {
        OnDetectPoint -= action;
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
                    // OnDetectPoint?.Invoke(hit.collider.transform.position);
                    OnDetectPoint?.Invoke(hit.collider.gameObject.transform.position);



                }
            }
        }
    }


}
