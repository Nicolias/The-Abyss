using System.Collections.Generic;
using Agava.YandexGames;
using Reflex.Attributes;
using UnityEngine;

namespace Menu
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Shop _shop;
        [SerializeField] private MenuButtonsRoot _menuButtonsRoot;
        [SerializeField] private LeaderboardOpenPanel _leaderboard;
        [SerializeField] private Locolization _locolization;

        [SerializeField] private List<ItemData> _items;

        private AbilitiesConfig _abilitiesConfig;
        private SaveLoader _saveLoader;
        private AdServise _adServise;
        private AudioServise _audioServise;

        [Inject]
        public void Consturct(SaveLoader saveLoader, AdServise adServise)
        {
            _saveLoader = saveLoader;
            _adServise = adServise;
        }

        private void Awake()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            YandexGamesSdk.GameReady();
            if (PlayerAccount.IsAuthorized == false)
                PlayerAccount.StartAuthorizationPolling(1500);
#endif

            _abilitiesConfig = new AbilitiesConfig(_saveLoader, _items);

            _locolization.Initialize();
            _items.ForEach(item => item.SetLenguage(_locolization.CurrentLanguageCode));

            _menuButtonsRoot.Initialize(_abilitiesConfig, _shop, _leaderboard, _adServise);
            _shop.Initialize(_abilitiesConfig);
        }

        private void OnEnable()
        {
            _menuButtonsRoot.Enable();
        }

        private void OnDisable()
        {
            _menuButtonsRoot.Disable();
        }
    }
}
