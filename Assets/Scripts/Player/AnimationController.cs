using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void StartWalking()
    {
        _animator.SetBool("IsWalking", true);
    }

    public void StopWalking()
    {
        _animator.SetBool("IsWalking", false);
    }

    public void StartRunning()
    {
        _animator.SetBool("IsRunning", true);
    }

    public void StopRunning()
    {
        _animator.SetBool("IsRunning", false);
    }

    public void UsePower()
    {
        _animator.SetBool("IsUsingPower", true);
    }

    public void StopUsingPower()
    {
        _animator.SetBool("IsUsingPower", false);
    }

    public void Jump()
    {
        _animator.SetBool("IsJumping", true);
    }

    public void StopJumping()
    {
        _animator.SetBool("IsJumping", false);
    }
}
