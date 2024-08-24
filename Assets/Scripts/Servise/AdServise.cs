using Agava.YandexGames;
using System;
using UnityEngine;

public class AdServise
{
    public event Action RewardCallback;

    public void Show()
    {
        VideoAd.Show(OnOpenCallback, RewardCallback, OnCloseCallBack);
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
