using Lean.Localization;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    [SerializeField] private List<LeanLanguage> _languageVariatinos;
    [SerializeField] private List<string> _namesOnAnoutherLanguages;

    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public string ID { get; private set; }
    [field: SerializeField] public int EffectDuration { get; private set; }

    public string Name { get; private set; }

    public void SetLenguage(string languageCode)
    {
        for (int i = 0; i < _languageVariatinos.Count; i++)
            if (_languageVariatinos[i].TranslationCode == languageCode)
                Name = _namesOnAnoutherLanguages[i];

        if (string.IsNullOrEmpty(Name))
            throw new InvalidOperationException();
    }

    public abstract void Accept(AbilityVisitor abilityVisitor);
}
