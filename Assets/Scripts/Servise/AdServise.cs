using Agava.YandexGames;
using System;
using UnityEngine;

public class AdServise
{
    public event Action RewardCallback;

    public void Show()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            VideoAd.Show(OnOpenCallback, RewardCallback, OnCloseCallBack);
#endif        
        RewardCallback?.Invoke();
    }

    private void OnOpenCallback()
    {
        Time.timeScale = 0;
    }

    private void OnCloseCallBack()
    {
        Time.timeScale = 1;
    }
}
