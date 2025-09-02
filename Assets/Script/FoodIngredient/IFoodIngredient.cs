using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class IFoodIngredient : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private NameIngredient _nameIngredient;
    [SerializeField] private StateIngredient _currentStateIngredient;
    [SerializeField] private GameObject _currentPrefab;
    [SerializeField] public List<IngredientPrototype> _ingredientPrototype = new List<IngredientPrototype>();

    public int GetId()
    {
        return _id;
    }
    protected virtual void Awake()
    {
        _id = (int)_nameIngredient;
    }
    protected virtual void Start()
    {

        ChangeState(StateIngredient.Raw);

    }
    public virtual void ChangeState(StateIngredient stateIngredient)
    {
        if (_currentPrefab != null)
        {
            Destroy(_currentPrefab);
        }
        _currentPrefab = Instantiate(_ingredientPrototype.Find(x => x._stateIngredient == stateIngredient)._prefab);
        _currentPrefab.transform.parent = transform;
        _currentPrefab.transform.position = transform.position;




    }
}
[Serializable]
public class IngredientPrototype
{
    public StateIngredient _stateIngredient;
    public GameObject _prefab;
}
public enum StateIngredient
{
    Raw,
    Cooked,
    Burn,
    Chopped,
    Slice

}
public enum NameIngredient
{
    MeatPatty,
    Buns,
    Cheese,
    Lettuce,
    Meat,
    Carrot,


}
