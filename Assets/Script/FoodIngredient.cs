using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodIngredient : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private StateIngredient _stateIngredient;

    public int GetId()
    {
        return _id;
    }
    public enum StateIngredient
    {
        Raw,
        Cooked,
        Burn
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
