using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { private set; get; }
    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    [Header("Class")]
    [SerializeField] private RaycastController _raycastController;
    [SerializeField] private LoadingScene _loadingScene;
    [SerializeField] private MovePlayerController _movePlayerController;
    [SerializeField] private MarkerController _markerController;

    [SerializeField] private Player _player;
    // [SerializeField] private Player 

    [Header("Properties")]

    [SerializeField] private GameObject _moveMarkObj;
    [SerializeField] private GameObject _triggerMarkObj;


    // Start is called before the first frame update
    private async void Start()
    {
        BindingObject();
        await InitializationObject();
        await CreateObject();
        await PreparingGame();


    }
    private void BindingObject()
    {
        _raycastController = Instantiate(_raycastController);
        _movePlayerController = Instantiate(_movePlayerController);
        _markerController = Instantiate(_markerController);


    }
    private async Task InitializationObject()
    {

    }
    private async Task CreateObject()
    {
        _player = Instantiate(_player);
        _moveMarkObj = Instantiate(_moveMarkObj);
        _triggerMarkObj = Instantiate(_triggerMarkObj);
    }
    private async Task PreparingGame()
    {
        _markerController.SetMoveMarker(_moveMarkObj);
        _markerController.SetTriggerMarker(_triggerMarkObj);


        _movePlayerController.SetPlayer(_player.gameObject);
        _movePlayerController.SubscribeOnEndMove(_markerController.HideMoveMark);
        _movePlayerController.SubscribeOnEndMove(_markerController.HideTriggerObjMark);


        _raycastController.SetPlayer(_player.gameObject);
        _raycastController.SubscribeDetectPoint(_movePlayerController.MovePlayer);
        _raycastController.SubscribeDetectPoint(_markerController.ShowMoveMark);
        _raycastController.SubscribeDetectObj(_markerController.ShowTriggerObjMark);



    }


}
