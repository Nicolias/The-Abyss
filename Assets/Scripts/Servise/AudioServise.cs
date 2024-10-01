using Agava.WebUtility;
using System;
using UnityEngine;

public class AudioServise : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;

    private AdServise _adServise;

    public void Initialize(AdServise adServise)
    {
        if (adServise == null)
            throw new NullReferenceException();

        _adServise = adServise;
        
        WebApplication.InBackgroundChangeEvent += OnBackgroundChanged;
        _adServise.Opened += Paus;
        _adServise.Closed += UnPaus;

        _backgroundMusic.Play();
    }

    private void OnDestroy()
    {
        WebApplication.InBackgroundChangeEvent -= OnBackgroundChanged;
        _adServise.Opened -= Paus;
        _adServise.Closed -= UnPaus;
    }

    private void Paus()
    {
        AudioListener.pause = true;
        AudioListener.volume = 0f;
    }

    private void UnPaus()
    {
        AudioListener.pause = false;
        AudioListener.volume = 1f;
    }

    private void OnBackgroundChanged(bool inBackground)
    {
        AudioListener.pause = inBackground;
        AudioListener.volume = inBackground ? 0f : 1f;
    }
}
