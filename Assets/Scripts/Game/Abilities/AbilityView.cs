using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AbilityView : MonoBehaviour
{
    [SerializeField] private TMP_Text _count;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;

    private Button _button;

    public event Action Clicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void Initialize(ItemModel model)
    {
        if (model == null)
            throw new ArgumentNullException();

        UpdateCountText(model.Count);
        _icon.sprite = model.Data.Sprite;
        _name.text = model.Data.Name;
    }

    public void UpdateCountText(int count)
    {
        _count.text = count.ToString();
    }

    public void Enable()
    {
        _button.interactable = true;
    }

    public void Disable()
    {
        _button.interactable = false;
    }

    private void OnClick()
    {
        Clicked?.Invoke();
    }
}