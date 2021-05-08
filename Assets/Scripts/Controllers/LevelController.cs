using Scripts;


public sealed class LevelController : BaseController, IInitialization, IExecute, ICleanUp
{
    public static int CountScore;
    private readonly GameLevelInfo _score;

    public LevelController()
    {
        _score = Data.Instance.GameLevelData.GetGameLevelInfo(GameLevelType.Test);
    }

    public void Initialization()
    {
        CountScore = 0;
        Services.Instance.EventService.OnChangeScore += ChangeScore;
    }

    public void Execute()
    {
        ShowLevel();
    }

    private void ChangeScore(int score)
    {
        CountScore += score;
        uiInterface.UiShowScore.Text = CountScore;
    }

    private void ShowLevel()
    {
        ShowCurrentLevel(LevelGame.levelOne, _score.levelOneScore, _score.levelTwoScore);
        ShowCurrentLevel(LevelGame.levelTwo, _score.levelTwoScore, _score.levelThreeScore);
        ShowCurrentLevel(LevelGame.levelThree, _score.levelThreeScore, _score.levelFourScore);
        ShowCurrentLevel(LevelGame.levelFour, _score.levelFourScore, _score.levelFiveScore);
        ShowCurrentLevel(LevelGame.levelFive, _score.levelFiveScore, _score.levelSixScore);
        ShowCurrentLevel(LevelGame.levelSix, _score.levelSixScore, _score.levelSevenScore);
        ShowCurrentLevel(LevelGame.levelSeven, _score.levelSevenScore, _score.levelEightScore);
        ShowCurrentLevel(LevelGame.levelEight, _score.levelEightScore, _score.levelNineScore);
        ShowCurrentLevel(LevelGame.levelNine, _score.levelNineScore, _score.levelTenScore);
        ShowCurrentLevel(LevelGame.levelTen, _score.levelTenScore, _score.levelTenScore * 2);
    }

    private void ShowCurrentLevel(LevelGame levelGame, int currentLevelScore, int nextLevelScore)
    {
        if (CountScore >= currentLevelScore && CountScore < nextLevelScore)
        {
            ShowLevel((int)levelGame);
            CalculateSlider(currentLevelScore, nextLevelScore);
            ShowGroundLevel(levelGame);
        }
    }

    private void CalculateSlider(float currentLevel, float nextLevel)
    {
        if (uiInterface.UiSlider)
        {
            uiInterface.UiSlider.GetSlider.value = (CountScore - currentLevel) / (nextLevel - currentLevel);
        }
    }

    private void ShowLevel(int level)
    {
        if (uiInterface.UiShowLevel)
        {
            uiInterface.UiShowLevel.Text = level;
        }

        if (uiInterface.UiShowNextLevel)
        {
            uiInterface.UiShowNextLevel.Text = level + 1;
        }

        if (uiInterface.UiShowPassedLevel)
        {
            uiInterface.UiShowPassedLevel.Text = level;
        }
    }

    private void ShowGroundLevel(LevelGame level)
    {
        switch (level)
        {
            case LevelGame.levelOne:
                uiInterface.UiGameScreen.ChangeGround(VisualLevelGame.GreenMountians);
                break;
            case LevelGame.levelTwo:
                uiInterface.UiGameScreen.ChangeGround(VisualLevelGame.SnowMountians);
                break;
            case LevelGame.levelThree:
                uiInterface.UiGameScreen.ChangeGround(VisualLevelGame.Swamp);
                break;
            case LevelGame.levelFour:
                uiInterface.UiGameScreen.ChangeGround(VisualLevelGame.Castle);
                break;
            case LevelGame.levelFive:
                uiInterface.UiGameScreen.ChangeGround(VisualLevelGame.LavaCastle);
                break;
            case LevelGame.levelSix:
                uiInterface.UiGameScreen.ChangeGround(VisualLevelGame.GreenMountians);
                break;
            case LevelGame.levelSeven:
                uiInterface.UiGameScreen.ChangeGround(VisualLevelGame.SnowMountians);
                break;
            case LevelGame.levelEight:
                uiInterface.UiGameScreen.ChangeGround(VisualLevelGame.Swamp);
                break;
            case LevelGame.levelNine:
                uiInterface.UiGameScreen.ChangeGround(VisualLevelGame.Castle);
                break;
            case LevelGame.levelTen:
                uiInterface.UiGameScreen.ChangeGround(VisualLevelGame.LavaCastle);
                break;
        }
    }

    public void Cleaner()
    {
        Services.Instance.EventService.OnChangeScore -= ChangeScore;
    }
}