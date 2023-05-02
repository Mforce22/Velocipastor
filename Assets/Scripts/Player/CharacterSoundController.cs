using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundController : MonoBehaviour
{
    #region Serialized Fields
    [Header("Audio Source")]
    [SerializeField] private AudioSource _AudioSource;

    [Header("Jump")]
    [SerializeField] private AudioClip _JumpClip;

    [Header("Power")]
    [SerializeField] private AudioClip _PowerClip;
    #endregion

    public void PlayJump()
    {
        _AudioSource.PlayOneShot(_JumpClip);
    }

    public void PlayPower()
    {
        _AudioSource.PlayOneShot(_PowerClip);
    }
}
