using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : Singleton<PauseMenuController>
{

    [Header("Pause Menu")]
    [Tooltip("Id of the gameplay input provider")]
    [SerializeField] private IdContainer _IdProvider;
    private GameplayInputProvider _gameplayInputProvider;


    private void Awake()
    {
        _gameplayInputProvider = PlayerController.Instance.GetInput<GameplayInputProvider>(_IdProvider.Id);
    }

    private void OnDisable()
    {
        _gameplayInputProvider.OnRestart?.Invoke();
    }
    public void ChangeScene(string name)
    {
        TravelSystem.Instance.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Continue()
    {

        //_gameplayInputProvider.OnRestart?.Invoke();
        Destroy(gameObject);
    }
}
