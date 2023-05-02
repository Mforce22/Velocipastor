using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    #region Serialized Fields
    [Header("Character Controller")]
    [SerializeField] private IdContainer _IdProvider;


    [Header("Character Movement")]
    [SerializeField] private float _speed = 200f;

    [Header("Player Audio Controller")]
    [SerializeField] private CharacterSoundController _SoundController;

    [Header("Options Menu")]
    [SerializeField] private PauseMenuController _PauseMenu;

    [Header("Character Physics")]
    [Tooltip("The rigidbody of the character")]
    [SerializeField] private Rigidbody _Rigidbody;

    //character jump
    [Header("Character Jump")]
    [Tooltip("The jump speed of the character")]
    [SerializeField] private float _JumpSpeed = 10f;

    [Tooltip("The delay before the character can jump again")]
    [SerializeField] private float _JumpDelay = 3f;


    [Header("Character Power")]
    [Tooltip("The delay before the character can use the power again")]
    [SerializeField] private float _PowerDelay = 5f;

    #endregion
    private PauseMenuController _PauseMenuController;
    private GameplayInputProvider _gameplayInputProvider;
    private Vector3 _moveDirection = Vector3.zero;

    private bool _canMove = true;
    private bool _canUsePower = true;

    private float _jumpCountdown = 0f;
    private float _currentSpeed;

    private void Awake()
    {
        _gameplayInputProvider = PlayerController.Instance.GetInput<GameplayInputProvider>(_IdProvider.Id);
        _gameplayInputProvider.EnableInput();
        _currentSpeed = _speed;
    }

    private void OnEnable()
    {
        _gameplayInputProvider.OnMove += MoveCharacter;
        _gameplayInputProvider.OnJump += JumpCharacter;
        _gameplayInputProvider.OnZMovePositive += ZMove;
        _gameplayInputProvider.OnPause += Pause;
        _gameplayInputProvider.OnRestart += Restart;
        _gameplayInputProvider.OnDash += Dash;
        _gameplayInputProvider.OnPower += Power;
    }
    private void OnDisable()
    {
        _gameplayInputProvider.OnMove -= MoveCharacter;
        _gameplayInputProvider.OnJump -= JumpCharacter;
        _gameplayInputProvider.OnZMovePositive -= ZMove;
        _gameplayInputProvider.OnPause -= Pause;
        _gameplayInputProvider.OnRestart -= Restart;
        _gameplayInputProvider.OnDash -= Dash;
        _gameplayInputProvider.OnPower -= Power;
    }

    private void Update()
    {
        if (_canMove)
        {
            transform.Translate(_moveDirection * _currentSpeed * Time.deltaTime);
            if (_jumpCountdown > 0)
            {
                _jumpCountdown -= Time.deltaTime;
            }
        }
    }

    private void JumpCharacter()
    {
        if (_jumpCountdown > 0 || !_canMove)
        {
            return;
        }
        _Rigidbody.AddForce(Vector3.up * _JumpSpeed, ForceMode.Impulse);
        _SoundController.PlayJump();
        _jumpCountdown = _JumpDelay;
        //Debug.Log("JUMP");
    }

    private void MoveCharacter(float value)
    {
        //move the character
        // Vector3 dir = new Vector3(value, 0, 0);
        _moveDirection = new Vector3(value, 0, _moveDirection.z);
        // transform.Translate(dir * _speed * Time.deltaTime);
        //Debug.LogFormat("Value: {0}", value);
    }

    private void ZMove(float value)
    {
        _moveDirection = new Vector3(_moveDirection.x, 0, value);
        //Debug.Log("ZMove " + value);
    }

    private void Pause()
    {
        //Debug.Log("PAUSE");
        if (_PauseMenuController)
        {
            Destroy(_PauseMenuController.gameObject);
            return;
        }
        _PauseMenuController = Instantiate(_PauseMenu);


        _Rigidbody.constraints = RigidbodyConstraints.FreezeAll;

        _canMove = !_canMove;
    }

    private void Restart()
    {
        //Debug.Log("RESTART");

        _Rigidbody.constraints = RigidbodyConstraints.None;
        _canMove = true;
    }

    private void Dash(float value)
    {
        //Debug.Log("Dash");
        _currentSpeed = _speed + (_speed * value);
    }

    private void Power()
    {
        if (_canUsePower)
        {
            //Debug.Log("Power Performed");
            _gameplayInputProvider.OnUsedPower?.Invoke();

            _canUsePower = false;
            StartCoroutine(PowerCooldown());
        }
    }

    private IEnumerator PowerCooldown()
    {
        //Debug.Log("Power Cooldown");
        yield return new WaitForSeconds(_PowerDelay);
        //Debug.Log("Power Cooldown End");
        _gameplayInputProvider.OnPowerEnd?.Invoke();
        _canUsePower = true;

    }


}
