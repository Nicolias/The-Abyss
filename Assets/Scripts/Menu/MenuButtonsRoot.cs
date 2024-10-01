using IJunior.TypedScenes;
using System;
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
        private YandexLeaderboard _leaderboard;
        private AdServise _adServise;

        public void Initialize(AbilitiesConfig abilitiesConfig, Shop shop, YandexLeaderboard leaderboard, AdServise adServise)
        {
            if (abilitiesConfig == null)
                throw new ArgumentNullException();

            if (adServise == null)
                throw new ArgumentNullException();

            if(leaderboard == null)
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
            _leaderboardButton.onClick.AddListener(_leaderboard.Open);
        }

        public void Disable()
        {
            _playButton.onClick.RemoveListener(LoadGame);
            _shopButton.onClick.RemoveListener(_shop.Open);
            _leaderboardButton.onClick.RemoveListener(_leaderboard.Open);
        }

        private void LoadGame()
        {
            Game.Load(new GameConfig(_abilitiesConfig));            
        }
    }
}
