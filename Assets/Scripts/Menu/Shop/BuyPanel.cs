using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanel : MonoBehaviour
{
    [SerializeField] private Button _buyButton;

    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _itemPriceText;
    [SerializeField] private Image _itemImage;

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

        _itemNameText.text = item.Data.Name;
        _itemPriceText.text = item.Data.Price.ToString();
        _itemImage.sprite = item.Data.Sprite;
    }

    private void TryBuy()
    {
        if (_wallet.Value >= _currentItem.Data.Price)
        {
            _wallet.Spent(_currentItem.Data.Price);
            _currentItem.Add();
        }

        gameObject.SetActive(false);
    }
}
