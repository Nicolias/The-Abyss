using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;

public class YandexLeaderboard : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard12";
    private const string AnonymousName = "Anonymous";

    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new List<LeaderboardPlayer>();

    [SerializeField] private LeaderboardCellFactory _leaderboardCellFactory;

    public void Open()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
            PlayerAccount.RequestPersonalProfileDataPermission();

        if (PlayerAccount.IsAuthorized == false)
            return;    

#endif
        gameObject.SetActive(true);
        Fill();
    }

    private void Fill()
    {
        _leaderboardPlayers.Clear();
#if UNITY_WEBGL && !UNITY_EDITOR
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
#endif
    }
}
