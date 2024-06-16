using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractItem : MonoBehaviour
{
    [SerializeField] private Button _button;

    private AbilitiesConfig _abilityConfig;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClicked);
    }

    public void Initialize(AbilitiesConfig abilitieConfig)
    {
        if (abilitieConfig == null)
            throw new ArgumentNullException();

        _abilityConfig = abilitieConfig;
    }

    private void OnClicked()
    {
        Buy();
    }

    private void Buy()
    {
        _abilityConfig.Add(this, 1);
    }
}
