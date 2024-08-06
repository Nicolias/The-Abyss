using System;
using UnityEngine;

public class FreezeTimeAbilitie : AbstractAbilitie
{
    [SerializeField] private Timer _timer;

    protected override AbstractItemModel Model { get; set; }

    protected override event Action EffectEnd;

    public void Initialize()
    {
        //Model = timeAbilityModel;
        OnInitialized();
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