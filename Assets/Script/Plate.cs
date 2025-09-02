
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour, IKitchenware
{
    [SerializeField] private Transform _pivotSurface;
    public List<IFoodIngredient> _listFoodIngredientInPlate = new List<IFoodIngredient>();
    public void KitchenwareFunction(PlayerHandController playerHandController)
    {
        _listFoodIngredientInPlate.Add(playerHandController.GetCurrentItemInHand().GetComponent<IFoodIngredient>());
        playerHandController.GetCurrentItemInHand().GetComponent<IFoodIngredient>().gameObject.transform.parent = gameObject.transform;
        playerHandController.GetCurrentItemInHand().GetComponent<IFoodIngredient>().gameObject.transform.position = _pivotSurface.position;
        playerHandController.EmptyHand();

    }
    public void CheckFoodIngredientInPlate()
    {

    }


}
