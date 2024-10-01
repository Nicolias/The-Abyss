using Agava.YandexGames;
using System;
using UnityEngine;

public class AdServise
{
    private Action _onCloseCallBack;

    public event Action Opened;
    public event Action RewardCallback;
    public event Action Closed;

    public void ShowReward()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        VideoAd.Show(OnOpenCallback, OnRewardCallback, OnRewardCloseCallBack);
#endif
    }

    public void ShowInterstation(Action onCompleteCallBack)
    {
        if (onCompleteCallBack == null)
            throw new NullReferenceException();

        _onCloseCallBack = onCompleteCallBack;

#if UNITY_WEBGL && !UNITY_EDITOR
        InterstitialAd.Show(OnOpenCallback, OnCloseCallBack);
#else
        OnCloseCallBack(true);
#endif
    }

    private void OnOpenCallback()
    {
        Time.timeScale = 0;
        Opened?.Invoke();
    }

    private void OnCloseCallBack(bool obj)
    {
        Continue();
        _onCloseCallBack?.Invoke();

        _onCloseCallBack = null;
    }

    private void OnRewardCallback()
    {
        RewardCallback?.Invoke();
        Continue();
    }

    private void OnRewardCloseCallBack()
    {
        Continue();
    }

    private void Continue()
    {
        Time.timeScale = 1;
        Closed?.Invoke();
    }
}
