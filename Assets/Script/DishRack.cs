using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DishRack : MonoBehaviour, ITriggerObject
{
    [SerializeField] private GameObject PlatePrefab;

    public void TriggerEvent()
    {
        Debug.Log("Đến chỗ DishRack");

        ObserverManager.Notify(ObserverEvent.TriggerObjectTakeItem, PlatePrefab);
        ObserverManager.RemoveListener(ObserverEvent.EndMoveNavigation, this.TriggerEvent);



    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
