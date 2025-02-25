using Agava.WebUtility;
using System;
using UnityEngine;

public class AudioServise : MonoBehaviour, IPausableObject
{
    [SerializeField] private AudioSource _backgroundMusic;

    public void Initialize(PausServise pausServise)
    {
        if (pausServise == null)
            throw new NullReferenceException();

        pausServise.Add(this);
        _backgroundMusic.Play();
    }

    public void Paus()
    {
        AudioListener.pause = true;
        AudioListener.volume = 0f;
    }

    public void UnPaus()
    {
        AudioListener.pause = false;
        AudioListener.volume = 1f;
    }
}
