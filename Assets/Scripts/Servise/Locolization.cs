using Agava.YandexGames;
using Lean.Localization;
using TMPro;
using UnityEngine;

public class Locolization : MonoBehaviour
{
    private const string English = "English";
    private const string Russian = "Russian";
    private const string Turkish = "Turkish";

    private const string EnglishCode = "en";
    private const string TurkishCode = "tr";
    private const string RussianCode = "ru";

    [SerializeField] private LeanLocalization _leanLocalization;

    public string CurrentLanguageCode { get; private set; }

    public void Initialize()
    {
        ChangeLanguage();
    }

    private void ChangeLanguage()
    {
        string languageCode = RussianCode;

#if UNITY_WEBGL && !UNITY_EDITOR
        languageCode = YandexGamesSdk.Environment.i18n.lang;
#endif

        switch (languageCode)
        {
            case EnglishCode:
                _leanLocalization.SetCurrentLanguage(English);
                break;
            case TurkishCode:
                _leanLocalization.SetCurrentLanguage(Turkish);
                break;
            case RussianCode:
                _leanLocalization.SetCurrentLanguage(Russian);
                break;
        }

        CurrentLanguageCode = languageCode;
    }
}
