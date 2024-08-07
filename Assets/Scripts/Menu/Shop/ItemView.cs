using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _countText;

    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _image;

    private ItemModel _model;

    private BuyPanel _buyPanel;

    public void Initialize(BuyPanel buyPanel, ItemModel model)
    {
        if (buyPanel == null)
            throw new ArgumentNullException();

        if (model == null)
            throw new ArgumentNullException();

        _buyPanel = buyPanel;
        _model = model;

        _name.text = _model.Data.Name;
        _price.text = _model.Data.Price.ToString();
        _image.sprite = _model.Data.Sprite;

        OnChanged();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClicked);
        _model.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClicked);
        _model.Changed -= OnChanged;
    }

    private void OnClicked()
    {
        _buyPanel.Open(_model);
    }

    private void OnChanged()
    {
        _countText.text = _model.Count.ToString();
    }
}