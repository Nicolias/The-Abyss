using Agava.YandexGames;

public class LeaderboardReader
{
    private const string LeaderboardName = "Leaderboard12";

    public void SetPlayerScore(int score)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized == false) 
            return;

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if(result == null || result.score < score)
                Leaderboard.SetScore(LeaderboardName, score);
        });
#endif
    }
}