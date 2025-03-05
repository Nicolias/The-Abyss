using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Menu.Leaderboard
{
    public class LeaderboardCellFactory : MonoBehaviour
    {
        [SerializeField] private LeaderboardElement _tamplate;
        [SerializeField] private Transform _container;

        private List<LeaderboardElement> _spawnedElements = new List<LeaderboardElement>();

        public void ConstructLeaderboard(List<LeaderboardPlayer> leaderboards)
        {
            ClearLeaderboard();

            foreach (var player in leaderboards)
            {
                LeaderboardElement leaderboardElement = Instantiate(_tamplate, _container);
                leaderboardElement.Initialize(player.Name, player.Rank, player.Score);

                _spawnedElements.Add(leaderboardElement);
            }
        }

        private void ClearLeaderboard()
        {
            foreach (var element in _spawnedElements)
                Destroy(element.gameObject);

            _spawnedElements = new List<LeaderboardElement>();
        }
    }
}