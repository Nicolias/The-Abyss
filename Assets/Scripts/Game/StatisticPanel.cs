using System;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

public class StatisticPanel : MonoBehaviour
{
    [SerializeField] private AdPanelOpenAnimation _openAnimation;

    [SerializeField] private Button _showAdButton;
    [SerializeField] private Button _closeButton;

    private WalletModel _walletModel;
    private AdServise _adServise;

    private int _currentScore;

    private Action _onClosedCallback;

    [Inject]
    public void Construct(WalletModel walletModel, AdServise adServise)
    {
        if (walletModel == null)
            throw new NullReferenceException();

        if (adServise == null)
            throw new NullReferenceException();

        _adServise = adServise;
        _walletModel = walletModel;
        _openAnimation.Initialize(_showAdButton, _closeButton);
    }

    private void OnEnable()
    {
        _adServise.RewardCallback += OnReward;

        _closeButton.onClick.AddListener(Close);
        _showAdButton.onClick.AddListener(_adServise.ShowReward);
    }

    private void OnDisable()
    {
        _adServise.RewardCallback -= OnReward;

        _closeButton.onClick.RemoveListener(Close);
        _showAdButton.onClick.RemoveListener(_adServise.ShowReward);
    }

    public void Open(int currentScore, int maxScore, Action onClosedCallBack)
    {
        gameObject.SetActive(true);
        _currentScore = currentScore;
        _onClosedCallback = onClosedCallBack;

        _openAnimation.Show(currentScore, maxScore);
    }

    private void Close()
    {
        gameObject.SetActive(false);
        _onClosedCallback.Invoke();
        _walletModel.Accure(_currentScore);
    }

    private void OnReward()
    {
        _walletModel.Accure(_currentScore);
        Close();
    }
}
