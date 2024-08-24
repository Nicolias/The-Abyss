using Agava.YandexGames;
using IJunior.TypedScenes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Menu
{
    public class EntryPoint : MonoBehaviour, ISceneLoadHandler<int>
    {
        [SerializeField] private Shop _shop;
        [SerializeField] private MenuButtonsRoot _menuButtonsRoot;
        [SerializeField] private WalletSaver _wallet;
        [SerializeField] private YandexLeaderboard _leaderboard;
        [SerializeField] private Locolization _locolization;

        [SerializeField] private List<ItemData> _items;

        private AbilitiesConfig _abilitiesConfig;
        private SaveLoader _saveLoader;

        [Inject]
        public void Consturct(SaveLoader saveLoader)
        {
            _saveLoader = saveLoader;
        }

        private void Awake()
        {
            _abilitiesConfig = new AbilitiesConfig(_saveLoader, _items);
            _menuButtonsRoot.Initialize(_abilitiesConfig, _shop, _leaderboard);
            _locolization.Initialize();
            _leaderboard.Initialize();
            _shop.Initialize(_abilitiesConfig);
            _saveLoader.Initialize();
        }

        private void OnEnable()
        {
            _items.ForEach(item => item.SetLenguage(_locolization.CurrentLanguageCode));
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
