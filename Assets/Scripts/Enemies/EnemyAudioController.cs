using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioController : MonoBehaviour
{
    #region Serialized Fields
    [Header("Audio Source")]
    [SerializeField] private AudioSource _AudioSource;

    [Header("Death")]
    [SerializeField] private AudioClip _DeathClip;
    #endregion

    public void PlayDeath()
    {
        _AudioSource.PlayOneShot(_DeathClip);
    }
}
