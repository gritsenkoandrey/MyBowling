using Scripts;


public sealed class ScoreController : BaseController, IExecute, IInitialization
{
    public static int CountScore = 0;
    private GameLevelInfo _score;

    public void Initialization()
    {
        _score = Data.Instance.GameLevelData.GetGameLevelInfo(GameLevelType.Test);
    }

    public void Execute()
    {
        uiInterface.UiShowScore.Text = CountScore;
        ShowLevel();
    }

    private void ShowLevel()
    {
        ShowCurrentLevel(LevelGame.levelOne, _score.levelOneScore, _score.levelTwoScore);
        ShowCurrentLevel(LevelGame.leveTwo, _score.levelTwoScore, _score.levelThreeScore);
        ShowCurrentLevel(LevelGame.levelThree, _score.levelThreeScore, _score.levelFourScore);
        ShowCurrentLevel(LevelGame.levelFour, _score.levelFourScore, _score.levelFiveScore);
        ShowCurrentLevel(LevelGame.levelFive, _score.levelFiveScore, _score.levelSixScore);
        ShowCurrentLevel(LevelGame.levelSix, _score.levelSixScore, _score.levelSevenScore);
        ShowCurrentLevel(LevelGame.levelSeven, _score.levelSevenScore, _score.levelEightScore);
        ShowCurrentLevel(LevelGame.levelEight, _score.levelEightScore, _score.levelNineScore);
        ShowCurrentLevel(LevelGame.levelNine, _score.levelNineScore, _score.levelTenScore);
        ShowCurrentLevel(LevelGame.levelTen, _score.levelTenScore, _score.levelTenScore * 2);
    }

    private void ShowCurrentLevel(LevelGame levelGame, float currentLevelScore, float nextLevelScore)
    {
        if (CountScore >= currentLevelScore && CountScore < nextLevelScore)
        {
            ShowLevel((int)levelGame);
            CalculateSlider(currentLevelScore, nextLevelScore);
        }
    }

    private void CalculateSlider(float currentLevel, float nextLevel)
    {
        uiInterface.UiSlider.GetSlider.value = (CountScore - currentLevel) / (nextLevel - currentLevel);
    }

    private void ShowLevel(int level)
    {
        uiInterface.UiShowLevel.Text = level;
        uiInterface.UiShowNextLevel.Text = level + 1;
    }
}