using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EndGameAdPanel : MonoBehaviour
{
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

        if(adServise == null)
            throw new NullReferenceException();

        _adServise = adServise;
        _walletModel = walletModel;
    }

    private void OnEnable()
    {
        _adServise.RewardCallback += OnReward;

        _closeButton.onClick.AddListener(Close);
        _showAdButton.onClick.AddListener(_adServise.Show);
    }

    private void OnDisable()
    {
        _adServise.RewardCallback -= OnReward;

        _closeButton.onClick.RemoveListener(Close);
        _showAdButton.onClick.RemoveListener(_adServise.Show);
    }

    public void Open(int currentScore, Action onClosedCallBack)
    {
        _currentScore = currentScore;
        gameObject.SetActive(true);
        _onClosedCallback = onClosedCallBack;
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