using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Gameplay Controller")]
    [SerializeField] private IdContainer _IdProvider;


    private GameplayInputProvider _gameplayInputProvider;

    private void Awake()
    {
        _gameplayInputProvider = PlayerController.Instance.GetInput<GameplayInputProvider>(_IdProvider.Id);
        _gameplayInputProvider.EnableInput();
    }

    private void OnEnable()
    {
        _gameplayInputProvider.OnUsedPower += PlayerPower;
        _gameplayInputProvider.OnPowerEnd += PlayerPowerEnd;
    }
    private void OnDisable()
    {
        _gameplayInputProvider.OnUsedPower -= PlayerPower;
        _gameplayInputProvider.OnPowerEnd -= PlayerPowerEnd;
    }

    private void PlayerPower()
    {
        Debug.Log("Enemy Power");
    }

    private void PlayerPowerEnd()
    {
        Debug.Log("Enemy Power End");
    }
}
