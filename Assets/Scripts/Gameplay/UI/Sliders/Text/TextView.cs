using TMPro;
using UnityEngine;

namespace Scripts.Gameplay.UI.Sliders.Text
{
    [RequireComponent(typeof(TMP_Text))]
    public abstract class TextView : MonoBehaviour
    {
        private TMP_Text _text;

        protected TMP_Text Text => _text = _text != null ? _text : GetComponent<TMP_Text>();
    }
}