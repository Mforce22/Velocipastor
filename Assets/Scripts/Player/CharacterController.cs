using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Character Controller")]
    [SerializeField] private IdContainer _IdProvider;


    [Header("Character Movement")]
    [SerializeField] private float _speed = 400f;

    private GameplayInputProvider _gameplayInputProvider;
    private Vector3 _moveDirection = Vector3.zero;

    private void Awake()
    {
        _gameplayInputProvider = PlayerController.Instance.GetInput<GameplayInputProvider>(_IdProvider.Id);
    }

    private void OnEnable()
    {
        _gameplayInputProvider.OnMove += MoveCharacter;
        _gameplayInputProvider.OnJump += JumpCharacter;
        _gameplayInputProvider.OnZMovePositive += ZMove;
    }
    private void OnDisable()
    {
        _gameplayInputProvider.OnMove -= MoveCharacter;
        _gameplayInputProvider.OnJump -= JumpCharacter;
        _gameplayInputProvider.OnZMovePositive -= ZMove;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    private void JumpCharacter()
    {
        Debug.Log("JUMP");
    }

    private void MoveCharacter(float value)
    {
        //move the character
        // Vector3 dir = new Vector3(value, 0, 0);
        _moveDirection = new Vector3(value, 0, _moveDirection.z);
        // transform.Translate(dir * _speed * Time.deltaTime);
        Debug.LogFormat("Value: {0}", value);
    }

    private void ZMove(float value)
    {
        _moveDirection = new Vector3(_moveDirection.x, 0, value);
        Debug.Log("ZMove " + value);
    }


}
