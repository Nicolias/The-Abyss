using System;

public class WalletSaver
{
    private const string Key = nameof(WalletSaver);

    private readonly WalletModel _model;
    private readonly SaveLoader _saveLoader;

    public WalletSaver(SaveLoader saveLoader, WalletModel walletModel)
    {
        if(saveLoader == null) 
            throw new ArgumentNullException();

        if (walletModel == null)
            throw new ArgumentNullException();

        _saveLoader = saveLoader;
        _model = walletModel;
    }

    public void Load()
    {
        _model.Accure(_saveLoader.LoadOrDefault(Key));
        _model.Changed += Save;
    }

    private void Save()
    {
        _saveLoader.Save(Key, _model.Value);
    }
}