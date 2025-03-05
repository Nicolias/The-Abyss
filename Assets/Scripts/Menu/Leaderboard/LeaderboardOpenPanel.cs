using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Menu.Leaderboard
{
    public class LeaderboardOpenPanel : MonoBehaviour
    {
        [SerializeField] private YandexLeaderboard _yandexLeaderboard;

        [SerializeField] private Button _athorizedButton;
        [SerializeField] private Button _closeButton;

        private void OnEnable()
        {
            _athorizedButton.onClick.AddListener(Authorize);
            _closeButton.onClick.AddListener(ClosePanel);
        }

        private void OnDisable()
        {
            _athorizedButton.onClick.RemoveListener(Authorize);
            _closeButton.onClick.RemoveListener(ClosePanel);
        }

        public void OpenLeaderboard()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized)
            _yandexLeaderboard.Open();
        else
            gameObject.SetActive(true);
#else
            gameObject.SetActive(true);
#endif
        }

        private void Authorize()
        {
            PlayerAccount.Authorize(() =>
            {
                ClosePanel();
                _yandexLeaderboard.Open();
            });

            if (PlayerAccount.IsAuthorized)
                PlayerAccount.RequestPersonalProfileDataPermission();
        }

        private void ClosePanel()
        {
            gameObject.SetActive(false);
        }
    }
}