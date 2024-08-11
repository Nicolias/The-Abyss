using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanel : MonoBehaviour
{
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _closeButton;

    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _itemPriceText;
    [SerializeField] private Image _itemImage;

    [SerializeField] private GameObject _notEnoughMoneyPanel;

    private WalletFacade _wallet;

    private ItemModel _currentItem;

    public void Initialize(WalletFacade walletFacade)
    {
        _wallet = walletFacade;
    }

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(TryBuy);
        _closeButton.onClick.AddListener(() => gameObject.SetActive(false));
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(TryBuy);
        _closeButton.onClick.RemoveAllListeners();
    }

    public void Open(ItemModel item)
    {
        _currentItem = item;
        gameObject.SetActive(true);

        _itemNameText.text = item.Data.Name;
        _itemPriceText.text = "Price: " + item.Data.Price.ToString();
        _itemImage.sprite = item.Data.Sprite;
    }

    private void TryBuy()
    {
        if (_wallet.Value >= _currentItem.Data.Price)
        {
            _wallet.Spent(_currentItem.Data.Price);
            _currentItem.Add();
        }
        else
        {
            _notEnoughMoneyPanel.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
