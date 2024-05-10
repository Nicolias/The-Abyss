using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

public class OpenGameButton : MonoBehaviour
{
    [SerializeField] private Button button;

    private void OnEnable()
    {
        button.onClick.AddListener(() => Game.Load(new GameConfig()));
    }
}
