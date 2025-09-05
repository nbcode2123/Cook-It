
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour, IKitchenware
{
    [SerializeField] private Transform _pivotSurface;
    [SerializeField] private List<IFoodIngredient> _listFoodIngredientInPlate = new List<IFoodIngredient>();
    [SerializeField] private IFoodIngredient _newFoodIngredient;
    [SerializeField] private int _ingredientCounter;
    [SerializeField] private RecipeTag _recipeTag;
    public void KitchenwareFunction(PlayerHandController playerHandController)
    {
        // _listFoodIngredientInPlate.Add(playerHandController.GetCurrentItemInHand().GetComponent<IFoodIngredient>());
        // playerHandController.GetCurrentItemInHand().GetComponent<IFoodIngredient>().gameObject.transform.parent = gameObject.transform;
        // playerHandController.GetCurrentItemInHand().GetComponent<IFoodIngredient>().gameObject.transform.position = _pivotSurface.position;
        // playerHandController.EmptyHand();
        _newFoodIngredient = playerHandController.GetCurrentItemInHand().GetComponent<IFoodIngredient>();
        CheckFoodIngredientInPlate(_newFoodIngredient, playerHandController);

    }
    public void CheckFoodIngredientInPlate(IFoodIngredient foodIngredient, PlayerHandController playerHandController)
    {
        Debug.Log(foodIngredient.GetStateIngredient());
        if (_listFoodIngredientInPlate.Contains(foodIngredient))
        {
            return;
        }
        else if (_listFoodIngredientInPlate.Count == 0)
        {
            if (foodIngredient.GetIngredientName() == NameIngredient.Buns)
            {
                _listFoodIngredientInPlate.Add(foodIngredient);
                foodIngredient.gameObject.transform.parent = gameObject.transform;
                foodIngredient.gameObject.transform.position = _pivotSurface.position;
                _pivotSurface = foodIngredient.GetPivotSurface();

                playerHandController.EmptyHand();


            }
            else
            {
                return;
            }

        }
        else
        {

            if (foodIngredient.GetStateIngredient() == StateIngredient.Slice || foodIngredient.GetStateIngredient() == StateIngredient.Cooked)
            {
                _listFoodIngredientInPlate.Add(foodIngredient);
                foodIngredient.gameObject.transform.parent = gameObject.transform;
                foodIngredient.gameObject.transform.position = _pivotSurface.position;

                _pivotSurface = foodIngredient.GetPivotSurface();
                if (_listFoodIngredientInPlate[0].GetComponent<Buns>() != null)
                {
                    _listFoodIngredientInPlate[0].GetComponent<Buns>().UpdateTopBuns(_pivotSurface);

                }
                playerHandController.EmptyHand();
            }

        }

    }



}
