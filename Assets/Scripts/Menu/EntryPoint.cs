using Agava.YandexGames;
using IJunior.TypedScenes;
using Reflex.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Menu
{
    public class EntryPoint : MonoBehaviour, ISceneLoadHandler<int>
    {
        [SerializeField] private Shop _shop;
        [SerializeField] private MenuButtonsRoot _menuButtonsRoot;
        [SerializeField] private YandexLeaderboard _leaderboard;
        [SerializeField] private Locolization _locolization;

        [SerializeField] private List<ItemData> _items;

        [SerializeField] private TMP_Text _text;

        private AbilitiesConfig _abilitiesConfig;
        private SaveLoader _saveLoader;

        [Inject]
        public void Consturct(SaveLoader saveLoader)
        {
            _saveLoader = saveLoader;
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

            _menuButtonsRoot.Initialize(_abilitiesConfig, _shop, _leaderboard);
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

        public void OnSceneLoaded(int collectedMoney)
        {
            _leaderboard.SetPlayerScore(collectedMoney);
        }
    }
}
