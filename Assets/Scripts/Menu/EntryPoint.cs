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
        [SerializeField] private WalletFacade _wallet;
        [SerializeField] private YandexLeaderboard _leaderboard;
        [SerializeField] private Locolization _locolization;

        [SerializeField] private List<ItemData> _items;

        private AbilitiesConfig _abilitiesConfig;
        private SaveLoader _saveLoader;

        [Inject]
        public void Cunstruct(SaveLoader saveLoader)
        {
            if (saveLoader == null)
                throw new NullReferenceException();

            _saveLoader = saveLoader;
        }

        private void Awake()
        {
            _abilitiesConfig = new AbilitiesConfig(_saveLoader, _items);

            _wallet.Enable();
            _menuButtonsRoot.Initialize(_abilitiesConfig, _shop, _leaderboard);
        }

        private void OnEnable()
        {
            _menuButtonsRoot.Enable();
        }

        private IEnumerator Start()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            yield return YandexGamesSdk.Initialize();

                    YandexGamesSdk.GameReady();

                    if (PlayerAccount.IsAuthorized == false)
                        PlayerAccount.StartAuthorizationPolling(1500);
#endif
            yield return null;

            _locolization.Initialize();
            _items.ForEach(item => item.SetLenguage(_locolization.CurrentLanguageCode));
            _shop.Initialize(_wallet, _abilitiesConfig);
        }

        private void OnDisable()
        {
            _menuButtonsRoot.Disable();
            _wallet.Disable();
        }

        public void OnSceneLoaded(int collectedMoney)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            _leaderboard.SetPlayerScore(collectedMoney);
#endif
        }
    }
}
