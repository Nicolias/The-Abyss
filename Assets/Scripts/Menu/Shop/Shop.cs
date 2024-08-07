using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private BuyPanel _buyPanel;
    [SerializeField] private ItemsViewFactory _itemsViewFactory;

    [SerializeField] private Button _closeButton;

    public void Initialize(WalletFacade walletFacade, AbilitiesConfig abilitiesConfig)
    {
        _buyPanel.Initialize(walletFacade);

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
