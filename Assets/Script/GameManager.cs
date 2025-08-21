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
    [Header("Properties")]
    [SerializeField] private GameObject _player;
    // Start is called before the first frame update
    private async void Start()
    {
        BindingObject();
        await InitializationObject();
        await CreateObject();

    }
    private void BindingObject()
    {
        _raycastController = Instantiate(_raycastController);
    }
    private async Task InitializationObject()
    {

    }
    private async Task CreateObject()
    {
        _player = Instantiate(_player);

    }
    private async Task PreparingGame()
    {

    }


}
