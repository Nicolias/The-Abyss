using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Gameplay.UI.Panels
{
    public class AdPanelOpenAnimation : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        [SerializeField] private TMP_Text _currentRewardText;
        [SerializeField] private TMP_Text _maxRewardText;

        [SerializeField] private Animator _showAdButtonAnimator;

        private Button _showAdButton;
        private Button _closeButton;

        public void Initialize(Button showAdButton, Button closeButton)
        {
            _showAdButton = showAdButton;
            _closeButton = closeButton;
        }

        private void Update()
        {
            _currentRewardText.text = _slider.value.ToString("0");
        }

        public void Show(int currentScore, int maxScore)
        {
            _slider.minValue = 0;
            _slider.value = 0;
            _slider.maxValue = maxScore;

            _currentRewardText.text = currentScore.ToString();
            _maxRewardText.text = maxScore.ToString();

            gameObject.transform.localScale = Vector3.zero;
            _closeButton.transform.localScale = Vector3.zero;
            _showAdButton.transform.localScale = Vector3.zero;

            gameObject.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                Sequence sequence = DOTween.Sequence();

                sequence
                .Append(_showAdButton.transform.DOScale(Vector3.one, 0.5f).OnComplete(() => _showAdButtonAnimator.enabled = true))
                .Append(_slider.DOValue(currentScore, 2f))
                .Append(_closeButton.transform.DOScale(Vector3.one, 0.5f));
            });
        }
    }
}