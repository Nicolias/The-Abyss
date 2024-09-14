public class SoundObject : AudioObject
{
    public void Initialize(SoundConfig soundConfig)
    {
        OnInitialize(soundConfig);
    }

    public void PlaySound()
    {
        PlayAudio();
    }
}