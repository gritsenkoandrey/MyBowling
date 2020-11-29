using Scripts;


public sealed class ScoreController : BaseController, IInitialization, IExecute
{
    public static int CountScore = 0;

    private byte _levelOne = 1;
    private byte _leveTwo = 2;
    private byte _levelThree = 3;
    private byte _levelFour = 4;
    private byte _levelFive = 5;

    public void Initialization()
    {
        uiInterface.UiShowLevel.Text = _levelOne;
    }

    public void Execute()
    {
        uiInterface.UiShowScore.Text = CountScore;

        ShowLevel();
    }

    private void ShowLevel()
    {
        if (CountScore >= Data.Instance.GameLevelData.leveTwoScore)
        {
            uiInterface.UiShowLevel.Text = _leveTwo;
        }

        if (CountScore >= Data.Instance.GameLevelData.leveThreeScore)
        {
            uiInterface.UiShowLevel.Text = _levelThree;
        }

        if (CountScore >= Data.Instance.GameLevelData.levelFourScore)
        {
            uiInterface.UiShowLevel.Text = _levelFour;
        }

        if (CountScore >= Data.Instance.GameLevelData.levelFiveScore)
        {
            uiInterface.UiShowLevel.Text = _levelFive;
        }
    }
}