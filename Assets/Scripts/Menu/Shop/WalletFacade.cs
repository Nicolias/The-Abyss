using System;
using UnityEngine;
using Zenject;

public class WalletFacade : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;

    private WalletModel _model;

    private SaveLoader _saveLoader;
    private string _key = nameof(WalletFacade);

    public int Value => _model.Value;

    [Inject]
    public void Cunstruct(SaveLoader saveLoader, WalletModel walletModel)
    {
        if(saveLoader == null) 
            throw new ArgumentNullException();

        if (walletModel == null)
            throw new ArgumentNullException();

        _saveLoader = saveLoader;
        _model = walletModel;
        _walletView.Initialize(_model);
    }

    public void Enable()
    {
        _walletView.Enable();
    }

    public void Disable()
    {
        _walletView.Disable();
    }

    private void OnDestroy()
    {
        _saveLoader.Save(_key, Value);
    }

    public void Accure(int value)
    {
        _model.Accure(value);
    }

    public void Spent(int value)
    {
        _model.Spent(value);
    }
}