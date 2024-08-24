using System;
using TMPro;
using UnityEngine;
using Zenject;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private IChangeable _changable;

    [Inject]
    public void Construct(WalletModel walletModel)
    {
        if (walletModel == null)
            throw new ArgumentNullException();

        _changable = walletModel;
        OnChanged();
    }

    private void OnEnable()
    {
        _changable.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _changable.Changed -= OnChanged;
    }

    private void OnChanged()
    {
        _text.text = _changable.Value.ToString();
    }
}