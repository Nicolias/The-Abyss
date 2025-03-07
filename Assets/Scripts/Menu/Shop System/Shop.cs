using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Menu.ShopSystem
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private BuyPanel _buyPanel;
        [SerializeField] private ItemsViewFactory _itemsViewFactory;

        [SerializeField] private Button _closeButton;

        public void Initialize(AbilitiesConfig abilitiesConfig)
        {
            _itemsViewFactory.Initialize(abilitiesConfig.Items, _buyPanel);
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Close);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Close);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        private void Close()
        {
            gameObject.SetActive(false);
        }
    }
}