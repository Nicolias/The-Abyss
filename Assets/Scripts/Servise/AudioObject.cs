﻿using UnityEngine;

public abstract class AudioObject : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    protected void PlayAudio()
    {
        _audioSource.Play();
    }
}