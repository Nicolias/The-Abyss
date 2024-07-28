using System;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanel : MonoBehaviour
{
    [SerializeField] private Button _buyButton;

    private WalletFacade _wallet;

    private AbstractItemModel _currentItem;

    public void Initialize(WalletFacade walletFacade)
    {
        _wallet = walletFacade;
    }

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(TryBuy);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(TryBuy);
    }

    public void Open(AbstractItemModel item)
    {
        _currentItem = item;
        gameObject.SetActive(true);
    }

    private void TryBuy()
    {
        if (_wallet.Value >= _currentItem.Price)
        {
            _wallet.Spent(_currentItem.Price);
            _currentItem.Add();
        }

        gameObject.SetActive(false);
    }
}
