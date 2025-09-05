using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;



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
    [SerializeField] private PlayerHandController _playerHandController;
    [SerializeField] private OrderSystem _orderSystem;

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
        _playerHandController = Instantiate(_playerHandController);
        _orderSystem = Instantiate(_orderSystem);


    }
    private async UniTask InitializationObject()
    {

    }
    private async UniTask CreateObject()
    {
        _player = Instantiate(_player);
        _moveMarkObj = Instantiate(_moveMarkObj);
        _triggerMarkObj = Instantiate(_triggerMarkObj);
    }
    private async UniTask PreparingGame()
    {
        _markerController.SetMoveMarker(_moveMarkObj);
        _markerController.SetTriggerMarker(_triggerMarkObj);

        _movePlayerController.SetPlayer(_player.gameObject);
        _movePlayerController.SetPlayerHandController(_playerHandController);

        _raycastController.SetPlayer(_player.gameObject);

        _playerHandController.SetPlayer(_player);


        ObserverManager.AddListener<Vector3>(ObserverEvent.RayCastDetectPoint, _movePlayerController.MovePlayer);
        ObserverManager.AddListener<Vector3>(ObserverEvent.RayCastDetectPoint, _markerController.ShowMoveMark);
        ObserverManager.AddListener<GameObject>(ObserverEvent.RayCastDetectObj, _markerController.ShowTriggerObjMark);

        ObserverManager.AddListener(ObserverEvent.EndMoveNavigation, _markerController.HideMoveMark);
        ObserverManager.AddListener(ObserverEvent.EndMoveNavigation, _markerController.HideTriggerObjMark);











    }


}

