using System;
using UnityEngine;

public abstract class AudioObject : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private AudioConfig _audioConfig;

    protected void OnInitialize(AudioConfig audioConfig)
    {
        if (audioConfig == null)
            throw new NullReferenceException();

        _audioConfig = audioConfig;

        ChangeVolume(_audioConfig.IsSilence);
        _audioConfig.SilenceChanged += ChangeVolume;
    }

    private void OnDestroy()
    {
        _audioConfig.SilenceChanged -= ChangeVolume;
    }

    protected void PlayAudio()
    {
        _audioSource.Play();
    }

    private void ChangeVolume(bool isSilance)
    {
        _audioSource.volume = isSilance ? 0 : 1;
    }
}
