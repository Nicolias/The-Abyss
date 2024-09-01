using Agava.YandexGames;
using Reflex.Attributes;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
#if UNITY_WEBGL && !UNITY_EDITOR
        yield return YandexGamesSdk.Initialize();
#else
        yield return null;
#endif

        _saveLoader.Initialize();
        yield return new WaitUntil(() => _saveLoader.IsInitialized);

        _walletSaver.Load();

        SceneManager.LoadScene(1);
    }
}
