using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class IFoodIngredient : MonoBehaviour
{
    [SerializeField] protected int _id;
    [SerializeField] protected NameIngredient _nameIngredient;
    [SerializeField] protected StateIngredient _currentStateIngredient;
    [SerializeField] protected GameObject _currentPrefab;
    [SerializeField] protected List<IngredientPrototype> _ingredientPrototype = new List<IngredientPrototype>();
    [SerializeField] protected Transform _pivotSurface;
    public Transform GetPivotSurface()
    {
        return _pivotSurface;
    }
    public NameIngredient GetIngredientName()
    {
        return _nameIngredient;
    }
    public StateIngredient GetStateIngredient()
    {
        return _currentStateIngredient;
    }
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

        // ChangeState(StateIngredient.Raw);
        if (_ingredientPrototype.Find(x => x._stateIngredient == StateIngredient.Cooked) != null)
        {
            ChangeState(StateIngredient.Cooked);
        }
        else if (_ingredientPrototype.Find(x => x._stateIngredient == StateIngredient.Slice) != null)
        {
            ChangeState(StateIngredient.Slice);

        }

    }
    public virtual void ChangeState(StateIngredient stateIngredient)
    {
        if (_currentPrefab != null)
        {
            Destroy(_currentPrefab);
        }
        _currentStateIngredient = stateIngredient;

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
