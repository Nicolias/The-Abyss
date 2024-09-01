using Reflex.Core;
using UnityEngine;

public class ProjectInstaller : MonoBehaviour, IInstaller
{
    public void InstallBindings(ContainerBuilder builder)
    {
        SaveLoader saveLoader = new SaveLoader();
        WalletModel walletSaver = new WalletModel();

        builder.AddSingleton(saveLoader);
        builder.AddSingleton(walletSaver);
        builder.AddSingleton(new WalletSaver(saveLoader, walletSaver));
    }
}
