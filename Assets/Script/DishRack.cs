using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DishRack : MonoBehaviour, ITriggerObject
{
    [SerializeField] private GameObject PlatePrefab;

    public void TriggerEvent(PlayerHandController playerHandController)
    {
        Debug.Log("Đến chỗ DishRack");
        if (playerHandController.isHandEmpty())
        {
            GameObject tempPlate = Instantiate(PlatePrefab);
            ObserverManager.Notify(ObserverEvent.TriggerObjectTakeItem, tempPlate);

        }
        ObserverManager.RemoveListener<PlayerHandController>(ObserverEvent.EndMoveNavigation, this.TriggerEvent);






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
