using System;

public abstract class AudioConfig
{
    public bool IsSilence { get; private set; }

    public event Action<bool> SilenceChanged;

    public void ChangeMusicSilance()
    {
        IsSilence = !IsSilence;
        SilenceChanged?.Invoke(IsSilence);
    }

    public void ChangeSoundSilance()
    {
        IsSilence = !IsSilence;
        SilenceChanged?.Invoke(IsSilence);
    }
}
