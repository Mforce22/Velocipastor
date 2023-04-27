using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayInputProvider : InputProvider
{
    #region Delegate
    public OnFloatDelegate OnMove;
    public OnFloatDelegate OnZMovePositive;
    public OnVoidDelegate OnJump;
    public OnVoidDelegate OnPause;

    public OnVoidDelegate OnRestart;
    #endregion

    [Header("Gameplay")]
    [SerializeField]
    private InputActionReference _Move;

    [SerializeField]
    private InputActionReference _ZMovePositive;

    [SerializeField]
    private InputActionReference _Jump;

    [SerializeField]
    private InputActionReference _Pause;

    private void OnEnable()
    {
        _Move.action.Enable();
        _Jump.action.Enable();
        _ZMovePositive.action.Enable();
        _Pause.action.Enable();
        Debug.Log("Gameplay Input Provider Enabled");


        _Move.action.performed += MovePerfomed;
        _Jump.action.performed += JumpPerfomed;
        _ZMovePositive.action.performed += ZMovePositivePerfomed;
        _Pause.action.performed += PausePerfomed;

    }

    public void EnableInput()
    {
        _Move.action.Enable();
        _Jump.action.Enable();
        _ZMovePositive.action.Enable();
        _Pause.action.Enable();
        Debug.Log("Gameplay Input Provider Enabled Manually");
    }

    private void OnDisable()
    {
        _Move.action.Disable();
        _Jump.action.Disable();
        _ZMovePositive.action.Disable();
        _Pause.action.Disable();

        _Move.action.performed -= MovePerfomed;
        _Jump.action.performed -= JumpPerfomed;
        _ZMovePositive.action.performed -= ZMovePositivePerfomed;
        _Pause.action.performed -= PausePerfomed;

        Debug.Log("Gameplay Input Provider Disabled");
    }

    private void MovePerfomed(InputAction.CallbackContext obj)
    {
        float value = obj.action.ReadValue<float>();
        OnMove?.Invoke(value);
    }

    private void JumpPerfomed(InputAction.CallbackContext obj)
    {
        OnJump?.Invoke();
    }

    private void ZMovePositivePerfomed(InputAction.CallbackContext obj)
    {
        float value = obj.action.ReadValue<float>();
        //Debug.LogFormat("ZMovePositivePerfomed: {0}", value);
        OnZMovePositive?.Invoke(value);
    }

    private void PausePerfomed(InputAction.CallbackContext obj)
    {
        OnPause?.Invoke();
    }

}
