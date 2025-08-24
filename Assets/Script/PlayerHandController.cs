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
    public void PutItemToHand(GameObject item)
    {
        if (_itemInHand != null)
        {
            Destroy(_itemInHand); //! test
        }
        _itemInHand = Instantiate(item);
        // _itemInHand = item;
        _itemInHand.transform.position = _playerHand.transform.position;
        _itemInHand.transform.parent = _player.transform;

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
