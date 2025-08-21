using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMarker : MonoBehaviour
{
    private GameObject _moveMarkerObj;
    private GameObject _player;
    public void SetMarker(GameObject obj)
    {
        _moveMarkerObj = obj;
        _moveMarkerObj.SetActive(false);
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
        _moveMarkerObj.SetActive(true);
        _moveMarkerObj.transform.position = position;
    }
    public void HideMoveMark()
    {
        _moveMarkerObj.SetActive(false);
    }
}
