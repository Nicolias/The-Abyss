using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Servises
{
    [RequireComponent(typeof(Button))]
    public class ClickabelObject : AudioObject
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(PlayAudio);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PlayAudio);
        }
    }
}