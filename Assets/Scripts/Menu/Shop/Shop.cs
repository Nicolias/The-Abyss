using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private BuyPanel _buyPanel;

    [SerializeField] private List<AbstractItemView> _items = new List<AbstractItemView>();

    public void Initialize(WalletFacade walletFacade, AbilitiesConfig abilitiesConfig)
    {
        _buyPanel.Initialize(walletFacade);
        _items.ForEach(item => item.Initialize(_buyPanel, abilitiesConfig));
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
