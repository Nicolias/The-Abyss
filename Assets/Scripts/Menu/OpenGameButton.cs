using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

public class OpenGameButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(LoadGame);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(LoadGame);
    }

    public void LoadGame()
    {
        Game.Load(new GameConfig());
    }
}
