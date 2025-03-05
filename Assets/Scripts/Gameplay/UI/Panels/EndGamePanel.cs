using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts.Gameplay.UI.Panels
{
    public class EndGamePanel : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _openMenuButton;

        private GameConfig _gameConfig;

        public void Open()
        {
            gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(ResetGame);
            _openMenuButton.onClick.AddListener(OpenMenu);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(ResetGame);
            _openMenuButton.onClick.RemoveListener(OpenMenu);
        }

        public void Initialize(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
        }

        private void OpenMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        private void ResetGame()
        {
            IJunior.TypedScenes.Game.Load(_gameConfig);
        }
    }
}