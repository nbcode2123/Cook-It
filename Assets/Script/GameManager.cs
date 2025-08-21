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
    [SerializeField] private MoveMarker _moveMarker;

    [Header("Properties")]

    [SerializeField] private GameObject _moveMarkObj;
    [SerializeField] private GameObject _player;

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
        _moveMarker = Instantiate(_moveMarker);

    }
    private async Task InitializationObject()
    {

    }
    private async Task CreateObject()
    {
        _player = Instantiate(_player);
        _moveMarkObj = Instantiate(_moveMarkObj);

    }
    private async Task PreparingGame()
    {
        _raycastController.Subscribe(_movePlayerController.MovePlayer);
        _raycastController.Subscribe(_moveMarker.ShowMoveMark);
        _movePlayerController.SetPlayer(_player);
        _movePlayerController.SubscribeOnEndMove(_moveMarker.HideMoveMark);
        _moveMarker.SetMarker(_moveMarkObj);

    }


}
