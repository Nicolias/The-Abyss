using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractItemView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _price;

    [SerializeField] private TMP_Text _countText;

    private AbstractItemModel _model;

    private BuyPanel _buyPanel;

    public void Initialize(BuyPanel buyPanel, AbilitiesConfig abilitiesConfig)
    {
        if (buyPanel == null)
            throw new ArgumentNullException();

        if (abilitiesConfig == null)
            throw new ArgumentNullException();

        _buyPanel = buyPanel;
        _model = GetModel(abilitiesConfig);
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

    protected abstract AbstractItemModel GetModel(AbilitiesConfig abilitiesConfig);

    private void OnClicked()
    {
        _buyPanel.Open(_model);
    }

    private void OnChanged()
    {
        _countText.text = _model.Count.ToString();
    }
}