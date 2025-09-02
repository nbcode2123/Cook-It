using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerController : MonoBehaviour
{
    private GameObject _moveMarkObj;
    private GameObject _triggerMarkObj;
    public void SetMoveMarker(GameObject obj)
    {
        _moveMarkObj = obj;
        _moveMarkObj.SetActive(false);
    }
    public void SetTriggerMarker(GameObject obj)
    {
        _triggerMarkObj = obj;
        _triggerMarkObj.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowMoveMark(Vector3 position)
    {
        _moveMarkObj.SetActive(true);
        _moveMarkObj.transform.position = position;
    }
    public void HideMoveMark()
    {
        _moveMarkObj.SetActive(false);
    }
    public void ShowTriggerObjMark(GameObject obj)
    {
        _triggerMarkObj.SetActive(true);
        _triggerMarkObj.transform.position = obj.transform.position;
    }
    public void HideTriggerObjMark()
    {
        _triggerMarkObj.SetActive(false);

    }
}
