using System;
using System.Collections;
using UnityEngine;

public class AbilityModel
{
    private readonly CoroutineServise _coroutineServise;

    private readonly AbilityStarter _abilityStarter;
    private readonly AbilityFinisher _abilityFinisher;

    private ItemModel _item;

    public AbilityModel(AbilityStarter abilityStarter, AbilityFinisher abilityFinisher, ItemModel item, CoroutineServise coroutineServise)
    {
        if (abilityStarter == null)
            throw new ArgumentNullException();

        if (abilityFinisher == null)
            throw new ArgumentNullException();

        if (item == null)
            throw new ArgumentNullException();

        if(coroutineServise == null)
            throw new ArgumentNullException();

        _abilityStarter = abilityStarter;
        _abilityFinisher = abilityFinisher;
        _item = item;
        _coroutineServise = coroutineServise;

    }

    public int Count => _item.Count;
    public int EffectDuration => _item.Data.EffectDuration;
    public Sprite ItemSprite => _item.Data.Sprite;

    public event Action EffectEnd;
    public event Action EffectStarted;

    public event Action<int> CountChanged;
    public event Action<int> LeftTimeChanged;

    public void Enable()
    {
        _item.Changed += OnCountChange;
    }

    public void Disable()
    {
        _item.Changed -= OnCountChange;
    }

    public void PlayEffect()
    {
        if (_item.Count <= 0)
            throw new InvalidOperationException();

        _item.Remove();
        _coroutineServise.StartCoroutine(LifeEffect());
    }

    private IEnumerator LifeEffect()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);

        EffectStarted?.Invoke();

        _abilityStarter.Visit(_item.Data);

        for (int i = _item.Data.EffectDuration; i >= 0; i--)
        {
            LeftTimeChanged?.Invoke(i);
            yield return waitForSeconds;
        }

        _abilityFinisher.Visit(_item.Data);

        EffectEnd?.Invoke();
    }

    private void OnCountChange()
    {
        CountChanged?.Invoke(Count);
    }
}