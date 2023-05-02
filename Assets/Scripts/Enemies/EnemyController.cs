using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Gameplay Controller")]
    [SerializeField] private IdContainer _IdProvider;

    [Header("Enemy Animator")]
    [SerializeField] private Animator _animator;


    private GameplayInputProvider _gameplayInputProvider;
    private float _oldSpeed;

    private void Awake()
    {
        _gameplayInputProvider = PlayerController.Instance.GetInput<GameplayInputProvider>(_IdProvider.Id);
        _gameplayInputProvider.EnableInput();
    }

    private void OnEnable()
    {
        _gameplayInputProvider.OnUsedPower += PlayerPower;
        _gameplayInputProvider.OnPowerEnd += PlayerPowerEnd;

        //play one animation from 0 to 4
        int dance = Random.Range(0, 5);
        _animator.SetInteger("Dance", dance);
    }
    private void OnDisable()
    {
        _gameplayInputProvider.OnUsedPower -= PlayerPower;
        _gameplayInputProvider.OnPowerEnd -= PlayerPowerEnd;
    }

    private void PlayerPower()
    {
        Debug.Log("Enemy Power");
        _oldSpeed = _animator.speed;
        _animator.speed = 0f;
    }

    private void PlayerPowerEnd()
    {
        _animator.speed = _oldSpeed;
        Debug.Log("Enemy Power End");
    }
}
