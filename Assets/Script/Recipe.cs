using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct Food
{
    [SerializeField] public RecipeName _recipeName;
    [SerializeField] public List<NameIngredient> _ingredient;
}

public class Recipe : MonoBehaviour
{

    [SerializeField] public List<Food> ListRecipe = new List<Food>();


}
[Serializable]
public enum RecipeName
{
    Burger,
}
