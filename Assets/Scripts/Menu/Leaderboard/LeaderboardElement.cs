using TMPro;
using UnityEngine;

namespace Scripts.Menu.Leaderboard
{
    public class LeaderboardElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _rankText;

        public void Initialize(string name, int rank, int score)
        {
            _nameText.text = name;
            _scoreText.text = score.ToString();
            _rankText.text = rank.ToString();
        }
    }
}