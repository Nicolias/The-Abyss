using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<AdServise>().FromNew().AsSingle();
        Container.Bind<WalletModel>().FromNew().AsSingle();
    }
}