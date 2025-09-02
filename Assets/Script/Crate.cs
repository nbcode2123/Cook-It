using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, ITriggerObject
{
    [SerializeField] private IFoodIngredient Ingredient;
    public void TriggerEvent(PlayerHandController playerHandController)
    {
        if (playerHandController.isHandEmpty())
        {
            GameObject tempIngredient = Instantiate(Ingredient.gameObject);
            playerHandController.PutItemToHand(tempIngredient);
        }
        ObserverManager.RemoveListener<PlayerHandController>(ObserverEvent.EndMoveNavigation, TriggerEvent);
    }
}
