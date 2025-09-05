using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct Food
{

    [SerializeField] public RecipeTag _recipeTag;
    [SerializeField] public RecipeName _recipeName;
    [SerializeField] public List<NameIngredient> _ingredient;
}

public class Recipe : MonoBehaviour
{
    public static Recipe Instance { private set; get; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [SerializeField] public List<Food> ListRecipe = new List<Food>();
    public void CheckCompleteRecipe(List<IFoodIngredient> listFoodIngredient)
    {


    }


}
[Serializable]
public enum RecipeName
{
    CheeseBurger,
}
public enum RecipeTag
{
    Burger,
    Soup
}
