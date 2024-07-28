using IJunior.TypedScenes;
using UnityEngine;

namespace Menu
{
    public class EntryPoint : MonoBehaviour, ISceneLoadHandler<int>
    {
        [SerializeField] private Shop _shop;
        [SerializeField] private MenuButtonsRoot _menuButtonsRoot;
        [SerializeField] private WalletFacade _wallet;

        private AbilitiesConfig _abilitiesConfig;

        private int _moneyForAccure;

        private void Awake()
        {
            SaveLoader saveLoader = new SaveLoader();

            _abilitiesConfig = new AbilitiesConfig(saveLoader);

            _wallet.Initialize(saveLoader);
            _wallet.Enable();
            _wallet.Accure(_moneyForAccure);

            _shop.Initialize(_wallet, _abilitiesConfig);
            _menuButtonsRoot.Initialize(_abilitiesConfig, _shop);
        }

        private void OnEnable()
        {
            _menuButtonsRoot.Enable();
        }

        private void OnDisable()
        {
            _menuButtonsRoot.Disable();
            _wallet.Disable();
        }

        public void OnSceneLoaded(int collectedMoney)
        {
            _moneyForAccure = collectedMoney;
        }
    }
}
