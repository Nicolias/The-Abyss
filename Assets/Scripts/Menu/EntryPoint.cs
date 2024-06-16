using UnityEngine;

namespace Menu
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Shop _shop;
        [SerializeField] private MenuButtonsRoot _menuButtonsRoot;

        private AbilitiesConfig _abilitiesConfig;

        private void Awake()
        {
            _abilitiesConfig = new AbilitiesConfig();

            _shop.Initialize(_abilitiesConfig);
            _menuButtonsRoot.Initialize(_abilitiesConfig, _shop);
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
