using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button _closeButton;

    [SerializeField] private List<AbstractItem> _items = new List<AbstractItem>();

    public void Initialize(AbilitiesConfig abilitiesConfig)
    {
        _items.ForEach(item => item.Initialize(abilitiesConfig));
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
