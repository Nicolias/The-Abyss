using TMPro;
using UnityEngine;

namespace SliderViewNameSpace
{
    [RequireComponent(typeof(TMP_Text))]
    public abstract class TextView : MonoBehaviour
    {
        private TMP_Text _text;

        protected TMP_Text Text
        {
            get 
            {
                if(_text == null)
                    _text = GetComponent<TMP_Text>();

                return _text;
            }
        }
    }
}