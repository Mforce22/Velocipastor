using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJ : MonoBehaviour
{
    #region Serialized Fields
    [Header("Component")]
    [Tooltip("Audio source component")]
    [SerializeField] private AudioSource _AudioSource;

    [Header("Audio Clips")]
    [Tooltip("List of audio clips")]
    [SerializeField] private List<AudioClip> _AudioClips;
    #endregion

    private int _currentClipIndex;

    private void Awake()
    {
        Debug.Log(_AudioClips.Count);
        _currentClipIndex = Random.Range(0, _AudioClips.Count);
        _AudioSource.clip = _AudioClips[_currentClipIndex];
        _AudioSource.Play();
    }

    private void Update()
    {
        if (!_AudioSource.isPlaying)
        {
            _currentClipIndex = Random.Range(0, _AudioClips.Count);
            _AudioSource.clip = _AudioClips[_currentClipIndex];
            _AudioSource.Play();
        }
    }
}
