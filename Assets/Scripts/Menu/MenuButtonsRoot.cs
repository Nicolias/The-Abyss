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

        private AbilitiesConfig _abilitiesConfig;
        private Shop _shop;

        public void Initialize(AbilitiesConfig abilitiesConfig, Shop shop)
        {
            if (abilitiesConfig == null)
                throw new ArgumentNullException();

            if (shop == null)
                throw new ArgumentNullException();

            _abilitiesConfig = abilitiesConfig;
            _shop = shop;
        }

        public void Enable()
        {
            _playButton.onClick.AddListener(LoadGame);
            _shopButton.onClick.AddListener(_shop.Open);
        }

        public void Disable()
        {
            _playButton.onClick.RemoveListener(LoadGame);
            _shopButton.onClick.RemoveListener(_shop.Open);
        }

        private void LoadGame()
        {
            Game.Load(new GameConfig(_abilitiesConfig));
        }
    }
}
