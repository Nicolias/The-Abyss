using System.Collections.Generic;
using UnityEngine;

public class LeaderboardCellFactory : MonoBehaviour
{
    [SerializeField] private LeaderboardElement _tamplate;
    [SerializeField] private Transform _container;

    List<LeaderboardElement> _spawnedElements = new List<LeaderboardElement>();

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
            Destroy(element);

        _spawnedElements = new List<LeaderboardElement>();
    }
}