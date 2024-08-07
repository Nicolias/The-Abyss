using System;
using UnityEngine;

public class FreezeTimeAbilitie : AbilityView
{
    [SerializeField] private Timer _timer;

    //protected override ItemModel Model { get; set; }

    protected override event Action EffectEnd;

    public void Initialize()
    {
        //Model = timeAbilityModel;
       // UpdateCounText();
    }

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