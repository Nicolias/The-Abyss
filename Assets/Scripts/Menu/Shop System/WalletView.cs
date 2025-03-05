using System;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace Scripts.Menu.ShopSystem
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private IChangeable _changable;

        [Inject]
        public void Construct(WalletModel walletModel)
        {
            if (walletModel == null)
                throw new ArgumentNullException();

            _changable = walletModel;
        }

        private void OnEnable()
        {
            OnChanged();
            _changable.Changed += OnChanged;
        }

        private void OnDisable()
        {
            _changable.Changed -= OnChanged;
        }

        private void OnChanged()
        {
            _text.text = _changable.Value.ToString();
        }
    }
}