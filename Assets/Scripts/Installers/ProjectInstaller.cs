using Reflex.Core;
using UnityEngine;

public class ProjectInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private AudioServise _audioServise;

    public void InstallBindings(ContainerBuilder builder)
    {
        SaveLoader saveLoader = new SaveLoader();
        AdServise adServise = new AdServise();
        WalletModel walletSaver = new WalletModel();

        LeaderboardReader leaderboardReader = new LeaderboardReader();

        AudioServise audioServise = Instantiate(_audioServise);
        audioServise.Initialize(adServise);

        builder.AddSingleton(saveLoader);
        builder.AddSingleton(adServise);
        builder.AddSingleton(walletSaver);
        builder.AddSingleton(new WalletSaver(saveLoader, walletSaver));

        builder.AddSingleton(leaderboardReader);

        DontDestroyOnLoad(audioServise);
        builder.AddSingleton(audioServise, typeof(AudioServise));
    }
}
