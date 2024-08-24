using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SaveLoader saveLoader = new SaveLoader();
        WalletModel walletModel = new WalletModel();
        WalletSaver walletSaver = new WalletSaver(saveLoader, walletModel);

        Container.Bind<AdServise>().FromNew().AsSingle();
        Container.Bind<WalletModel>().FromInstance(walletModel).AsSingle();
        Container.Bind<SaveLoader>().FromInstance(saveLoader).AsSingle();
        Container.Bind<WalletSaver>().FromInstance(walletSaver).AsSingle();
    }
}