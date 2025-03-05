using Reflex.Core;
using Scripts.Menu.Leaderboard;
using Scripts.Menu.ShopSystem;
using Scripts.Servises;
using UnityEngine;

namespace Scripts.Installers
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private AudioServise _audioServise;
        [SerializeField] private PausServise _pauseServise;

        public void InstallBindings(ContainerBuilder builder)
        {
            PausServise pausServise = Instantiate(_pauseServise);
            AudioServise audioServise = Instantiate(_audioServise);

            SaveLoader saveLoader = new SaveLoader();
            AdServise adServise = new AdServise(pausServise);
            WalletModel walletSaver = new WalletModel();

            LeaderboardReader leaderboardReader = new LeaderboardReader();

            audioServise.Initialize(pausServise);

            builder.AddSingleton(saveLoader);
            builder.AddSingleton(adServise);
            builder.AddSingleton(walletSaver);
            builder.AddSingleton(new WalletSaver(saveLoader, walletSaver));

            builder.AddSingleton(leaderboardReader);

            DontDestroyOnLoad(audioServise);
            builder.AddSingleton(audioServise, typeof(AudioServise));

            DontDestroyOnLoad(pausServise);
            builder.AddSingleton(pausServise);
        }
    }
}