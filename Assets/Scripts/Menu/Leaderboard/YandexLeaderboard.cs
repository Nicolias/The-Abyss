using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;

public class YandexLeaderboard : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard";
    private const string AnonymousName = "Anonymous";

    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new();

    [SerializeField] private LeaderboardCellFactory _leaderboardCellFactory;

    public void Open()
    {
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
            PlayerAccount.RequestPersonalProfileDataPermission();

        if (PlayerAccount.IsAuthorized == false)
            return;

        gameObject.SetActive(true);
        Fill();
    }

    public void SetPlayerScore(int score)
    {
        if(PlayerAccount.IsAuthorized == false) 
            return;

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if(result == null || result.score < score)
                Leaderboard.SetScore(LeaderboardName, score);
        });
    }

    private void Fill()
    {
        _leaderboardPlayers.Clear();

        Leaderboard.GetEntries(LeaderboardName, (result) =>
        {
            foreach (var entry in result.entries)
            {
                int rank = entry.rank;
                int score = entry.score;
                string name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = AnonymousName;

                _leaderboardPlayers.Add(new LeaderboardPlayer(rank, name, score));
            }

            _leaderboardCellFactory.ConstructLeaderboard(_leaderboardPlayers);
        });
    }
}