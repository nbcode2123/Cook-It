using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class ShelfSlot : MonoBehaviour, ITriggerObject
{
    [SerializeField] private Transform _pivotSurface;
    [SerializeField] private GameObject _currentPlateInShelf;
    private void Awake()
    {
        _currentPlateInShelf = null;
    }
    public void SetCurrentShelf(GameObject item)
    {
        _currentPlateInShelf = item;
        _currentPlateInShelf.transform.parent = gameObject.transform;
        _currentPlateInShelf.transform.position = _pivotSurface.transform.position;
    }
    public void TriggerEvent(PlayerHandController playerHandController)
    {

        if (playerHandController.isFoodIngredientInHand() && isKitchenwareInShelf())
        {
            _currentPlateInShelf.GetComponent<IKitchenware>().KitchenwareFunction(playerHandController);
        }
        else
        {
            playerHandController.SwapItemInHand(this);
        }
        ObserverManager.RemoveListener<PlayerHandController>(ObserverEvent.EndMoveNavigation, this.TriggerEvent);










    }
    public bool isShelfEmpty()
    {
        if (_currentPlateInShelf == null)
        {
            return true;
        }
        else return false;
    }

    public GameObject GetCurrentItem()
    {
        return _currentPlateInShelf;

    }
    public void EmptySlot()
    {
        _currentPlateInShelf = null;
    }
    public bool isKitchenwareInShelf()
    {
        if (_currentPlateInShelf == null)
        {
            return false;
        }
        else
        {
            if (_currentPlateInShelf.GetComponent<IKitchenware>() == null)
            {
                return false;
            }
            else return true;
        }

    }
    public bool isFoodIngredientInShelf()
    {
        if (_currentPlateInShelf == null)
        {
            return false;
        }
        else
        {
            if (_currentPlateInShelf.GetComponent<IFoodIngredient>() == null)
            {
                return false;
            }
            else return true;
        }

    }

}
