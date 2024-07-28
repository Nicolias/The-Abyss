using System;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private IChangeable _changable;

    public void Initialize(IChangeable changeable)
    {
        if (changeable == null)
            throw new ArgumentNullException();

        _changable = changeable;
        OnChanged();
    }

    public void Enable()
    {
        _changable.Changed += OnChanged;
    }

    public void Disable()
    {
        _changable.Changed -= OnChanged;
    }

    private void OnChanged()
    {
        _text.text = _changable.Value.ToString();
    }
}