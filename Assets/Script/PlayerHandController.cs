using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _playerHand;
    [SerializeField] private GameObject _itemInHand;
    private void Awake()
    {
        ObserverManager.AddListener<GameObject>(ObserverEvent.TriggerObjectTakeItem, PutItemToHand);
        ObserverManager.AddListener<ShelfSlot>(ObserverEvent.PutItemToShelf, SwapItemInHand);
    }
    public void SetPlayer(Player player)
    {
        _player = player;
        SetPlayerHand(_player.GetPlayerHand());

    }
    private void SetPlayerHand(GameObject hand)
    {
        _playerHand = hand;
    }
    public bool isHandEmpty()
    {
        if (_itemInHand == null)
        {
            return true;

        }
        else
        {
            return false;
        }

    }
    public GameObject GetCurrentItemInHand()
    {
        return _itemInHand;
    }
    public void PutItemToHand(GameObject item)
    {


        _itemInHand = item;
        _itemInHand.transform.position = _playerHand.transform.position;
        _itemInHand.transform.parent = _player.transform;




    }
    public bool isKitchenwareInHand()
    {
        if (_itemInHand == null)
        {
            return false;
        }
        else
        {
            if (_itemInHand.GetComponent<IKitchenware>() == null)
            {
                return false;
            }
            else return true;
        }
    }
    public bool isFoodIngredientInHand()
    {
        if (_itemInHand == null)
        {
            return false;
        }
        else
        {
            if (_itemInHand.GetComponent<IFoodIngredient>() == null)
            {
                return false;
            }
            else return true;
        }
    }

    public void SwapItemInHand(ShelfSlot shelfSlot)
    {

        GameObject tempObject = shelfSlot.GetCurrentItem();
        if (_itemInHand != null)
        {
            shelfSlot.SetCurrentShelf(_itemInHand);

        }
        else
        {
            shelfSlot.EmptySlot();
        }
        if (tempObject == null)
        {
            _itemInHand = null;
            Debug.Log("tay null");
        }
        else
        {
            Debug.Log("Tay cam object");
            PutItemToHand(tempObject);

        }



    }
    public void EmptyHand()
    {
        _itemInHand = null;
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
