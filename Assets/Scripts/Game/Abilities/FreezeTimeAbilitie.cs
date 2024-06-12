using System;
using UnityEngine;

public class FreezeTimeAbilitie : AbstractAbilitie
{
    [SerializeField] private Timer _timer;

    protected override event Action EffectEnd;

    protected override void Enable()
    {
        _timer.Pause();
    }

    protected override void Disable()
    {
        _timer.UnPause();

        EffectEnd?.Invoke();
    }
}