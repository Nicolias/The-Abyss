using Agava.YandexGames;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SDKInitializer : MonoBehaviour
{
    private SaveLoader _saveLoader;
    private WalletSaver _walletSaver;

    [Inject]
    public void Cunstruct(SaveLoader saveLoader, WalletSaver walletSaver)
    {
        if (saveLoader == null)
            throw new NullReferenceException();

        if (walletSaver == null)
            throw new NullReferenceException();

        _saveLoader = saveLoader;
        _walletSaver = walletSaver;
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();

        YandexGamesSdk.GameReady();

        if (PlayerAccount.IsAuthorized == false)
            PlayerAccount.StartAuthorizationPolling(1500);

        _saveLoader.Initialize();
        _walletSaver.Load();

        SceneManager.LoadScene(1);
    }
}
