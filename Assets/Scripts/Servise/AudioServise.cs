using System.Collections.Generic;
using UnityEngine;

public class AudioServise : MonoBehaviour
{
    [SerializeField] private List<ClickabelObject> _clickableObject;
    [SerializeField] private List<SoundObject> _soundObjects;
    [SerializeField] private MusicObject _musicObject;

    public void Initialize(SoundConfig soundConfig, MusicConfig musicConfig)
    {
        _clickableObject.ForEach(soundObject => soundObject.Initialize(soundConfig));
        _soundObjects.ForEach(soundObject => soundObject.Initialize(soundConfig));
        _musicObject.Initialize(musicConfig);
    }
}
