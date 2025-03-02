using System;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class MenuButtonsRoot : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _shopButton;
        [SerializeField] private Button _leaderboardButton;

        private AbilitiesConfig _abilitiesConfig;
        private Shop _shop;
        private LeaderboardOpenPanel _leaderboard;
        private AdServise _adServise;

        public void Initialize(AbilitiesConfig abilitiesConfig, Shop shop, LeaderboardOpenPanel leaderboard, AdServise adServise)
        {
            if (abilitiesConfig == null)
                throw new ArgumentNullException();

            if (adServise == null)
                throw new ArgumentNullException();

            if (leaderboard == null)
                throw new ArgumentNullException();

            if (leaderboard == null)
                throw new ArgumentNullException();

            _abilitiesConfig = abilitiesConfig;
            _shop = shop;
            _leaderboard = leaderboard;
            _adServise = adServise;
        }

        public void Enable()
        {
            _playButton.onClick.AddListener(LoadGame);
            _shopButton.onClick.AddListener(_shop.Open);
            _leaderboardButton.onClick.AddListener(_leaderboard.OpenLeaderboard);
        }

        public void Disable()
        {
            _playButton.onClick.RemoveListener(LoadGame);
            _shopButton.onClick.RemoveListener(_shop.Open);
            _leaderboardButton.onClick.RemoveListener(_leaderboard.OpenLeaderboard);
        }

        private void LoadGame()
        {
            AsyncOperation asyncOperation = Game.LoadAsync(new GameConfig(_abilitiesConfig));
            asyncOperation.allowSceneActivation = false;

            _adServise.ShowInterstation(() => asyncOperation.allowSceneActivation = true);
        }
    }
}
