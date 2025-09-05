using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buns : IFoodIngredient
{
    [SerializeField] private GameObject _topBunsPrefab;
    [SerializeField] private Transform _topBunsTransform;
    protected override void Start()
    {
        ChangeState(StateIngredient.Raw);
        _topBunsTransform = _pivotSurface;
        _topBunsPrefab = Instantiate(_topBunsPrefab);
        _topBunsPrefab.transform.parent = gameObject.transform;
        _topBunsPrefab.transform.position = _topBunsTransform.transform.position;
    }
    public void UpdateTopBuns(Transform newPivot)
    {
        _topBunsTransform = newPivot;
        _topBunsPrefab.transform.position = newPivot.position;


    }

}
