public class LeaderboardReader
{
    public void SetPlayerScore(int score)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
            PlayerAccount.RequestPersonalProfileDataPermission();

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