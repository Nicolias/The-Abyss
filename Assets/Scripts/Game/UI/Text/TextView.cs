using TMPro;
using UnityEngine;

namespace SliderViewNameSpace
{
    [RequireComponent(typeof(TMP_Text))]
    public abstract class TextView : MonoBehaviour
    {
        protected TMP_Text Text { get; private set; }
        
        private void Awake()
        {
            Text = GetComponent<TMP_Text>();
        }
    }
}