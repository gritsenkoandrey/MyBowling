using Scripts;


public sealed class ScoreController : BaseController, IExecute
{
    public static int CountScore = 0;

    private byte _levelOne = 1;
    private byte _leveTwo = 2;
    private byte _levelThree = 3;
    private byte _levelFour = 4;
    private byte _levelFive = 5;

    public void Execute()
    {
        uiInterface.UiShowScore.Text = CountScore;

        ShowScore();
    }

    private void ShowScore()
    {
        if (CountScore < Data.Instance.GameLevelData.leveTwoScore)
        {
            ShowLevel(_levelOne);
            CalculateSlider(Data.Instance.GameLevelData.levelOneScore, Data.Instance.GameLevelData.leveTwoScore);
        }

        if (CountScore >= Data.Instance.GameLevelData.leveTwoScore)
        {
            ShowLevel(_leveTwo);
            CalculateSlider(Data.Instance.GameLevelData.leveTwoScore, Data.Instance.GameLevelData.leveThreeScore);
        }

        if (CountScore >= Data.Instance.GameLevelData.leveThreeScore)
        {
            ShowLevel(_levelThree);
            CalculateSlider(Data.Instance.GameLevelData.leveThreeScore, Data.Instance.GameLevelData.levelFourScore);
        }

        if (CountScore >= Data.Instance.GameLevelData.levelFourScore)
        {
            ShowLevel(_levelFour);
            CalculateSlider(Data.Instance.GameLevelData.levelFourScore, Data.Instance.GameLevelData.levelFiveScore);
        }

        if (CountScore >= Data.Instance.GameLevelData.levelFiveScore)
        {
            ShowLevel(_levelFive);
            CalculateSlider(Data.Instance.GameLevelData.levelFiveScore, Data.Instance.GameLevelData.levelSixScore);
        }
    }

    private void CalculateSlider(float currentLevel, float nextLevel)
    {
        uiInterface.UiSlider.GetSlider.value = (CountScore - currentLevel) / (nextLevel - currentLevel);
    }

    private void ShowLevel(byte level)
    {
        uiInterface.UiShowLevel.Text = level;
        uiInterface.UiShowNextLevel.Text = level + 1;
    }
}