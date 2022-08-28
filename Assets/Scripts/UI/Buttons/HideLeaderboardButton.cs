public class HideLeaderboardButton : ButtonBase
{
    protected override void OnPressed()
    {
        FindObjectOfType<UIManager>().HideLeaderboard();
    }
}
