using System;
using Agava.YandexGames;
using UnityEngine;

public class AdServise
{
    private Action _onCloseCallBack;
    private readonly PausServise _pausServise;

    public event Action Opened;

    public event Action RewardCallback;

    public event Action Closed;

    public AdServise(PausServise pausServise)
    {
        _pausServise = pausServise;
    }

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
        _pausServise.Paus();
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
    }

    private void OnRewardCloseCallBack()
    {
        Continue();
    }

    private void Continue()
    {
        _pausServise.UnPaus();
        Closed?.Invoke();
    }
}
