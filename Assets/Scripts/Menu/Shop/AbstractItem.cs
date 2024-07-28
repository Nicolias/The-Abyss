using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractItem : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _price;

    private AbilitiesConfig _abilityConfig;
    private WalletFacade _wallet;

    public void Initialize(AbilitiesConfig abilitieConfig, WalletFacade walletFacade)
    {
        if (abilitieConfig == null)
            throw new ArgumentNullException();

        _abilityConfig = abilitieConfig;
        _wallet = walletFacade;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClicked);
    }

    private void OnClicked()
    {
        if (_wallet.Value < _price)
            throw new InvalidOperationException();

        Buy();
    }

    private void Buy()
    {
        _abilityConfig.Add(this, 1);
        _wallet.Spent(_price);
    }
}