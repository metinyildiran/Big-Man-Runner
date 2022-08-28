public class ShowLeaderboardButton : ButtonBase
{
    protected override void OnPressed()
    {
        FindObjectOfType<UIManager>().ShowLeaderboard();
    }
}
