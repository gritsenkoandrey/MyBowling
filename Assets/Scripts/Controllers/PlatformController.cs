using DG.Tweening;
using Scripts;
using UnityEngine;


public sealed class PlatformController : BaseController, IExecute
{
    private GameLevelInfo _score;
    private PlatformInfo _platform;

    private bool _isReadySpawn;
    private bool _isStartSpawn;

    private BallBase _ball;

    private TimeRemaining _timeNextLevelUi;
    private TimeRemaining _timeGameOverUi;
    private readonly float _timeToShowNextLevelUi = 1.0f;
    private readonly float _timeToShowGameOverUi = 3.5f;

    private int _levelPassed;

    public PlatformController()
    {
        _score = Data.Instance.GameLevelData.GetGameLevelInfo(GameLevelType.Test);
        _platform = Data.Instance.PlatformData.GetPlatformInfo(PlatformType.Standart);

        _timeNextLevelUi = new TimeRemaining(ShowNextLevelUi, _timeToShowNextLevelUi);
        _timeGameOverUi = new TimeRemaining(ShowGameOverUi, _timeToShowGameOverUi);

        _levelPassed = (int)LevelGame.levelOne;

        _isReadySpawn = false;
        _isStartSpawn = false;
    }

    public void Execute()
    {
        SpawnPlatforms();
        DestroyPlatform();
    }

    private void SpawnPlatforms()
    {
        if (LevelController.CountScore >= _score.levelOneScore && LevelController.CountScore < _score.levelTwoScore)
        {
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelOne, _platform.duration, _platform.delay);
        }

        PlatformGenerationDependingLevel(_score.levelTwoScore, _score.levelThreeScore, LevelGame.levelTwo, Data.Instance.PrefabsData.platformsLevelTwo);
        PlatformGenerationDependingLevel(_score.levelThreeScore, _score.levelFourScore, LevelGame.levelThree, Data.Instance.PrefabsData.platformsLevelThree);
        PlatformGenerationDependingLevel(_score.levelFourScore, _score.levelFiveScore, LevelGame.levelFour, Data.Instance.PrefabsData.platformsLevelFour);
        PlatformGenerationDependingLevel(_score.levelFiveScore, _score.levelSixScore, LevelGame.levelFive, Data.Instance.PrefabsData.platformsLevelFive);
        PlatformGenerationDependingLevel(_score.levelSixScore, _score.levelSevenScore, LevelGame.levelSix, Data.Instance.PrefabsData.platformsLevelOne);
        PlatformGenerationDependingLevel(_score.levelSevenScore, _score.levelEightScore, LevelGame.levelSeven, Data.Instance.PrefabsData.platformsLevelTwo);
        PlatformGenerationDependingLevel(_score.levelEightScore, _score.levelNineScore, LevelGame.levelEight, Data.Instance.PrefabsData.platformsLevelThree);
        PlatformGenerationDependingLevel(_score.levelNineScore, _score.levelTenScore, LevelGame.levelNine, Data.Instance.PrefabsData.platformsLevelFour);
        PlatformGenerationDependingLevel(_score.levelTenScore, _score.levelTenScore * 2, LevelGame.levelTen, Data.Instance.PrefabsData.platformsLevelFive);
    }

    private void PlatformGenerationDependingLevel(int currentLevelScore, int nextLevelScore, LevelGame levelGame, string[] platforms)
    {
        if (LevelController.CountScore >= currentLevelScore && LevelController.CountScore < nextLevelScore)
        {
            if (_levelPassed != (int)levelGame)
            {
                _levelPassed = (int)levelGame;
                DestroyAllPlatform();
            }
            GeneratePlatform(platforms, _platform.duration, _platform.delay);
        }
    }

    private void GeneratePlatform(string[] platforms, float duration, float delay)
    {
        // генерация платформ когда все платформы уничтожены
        if (_isStartSpawn == false)
        {
            for (int i = _platform.currentPlatformCount; i < _platform.maxPlatformCount; i++)
            {
                var obj = PoolManager.GetObject(platforms[Random.Range(0, platforms.Length)],
                    new Vector3(0.0f, 0.0f, _platform.startPositionPlatforms[i]), Quaternion.identity);
                obj.GetComponent<Platform>().SpawnObjectOnPlatform();
                MovePlatform(obj, duration, delay);
                _platform.currentPlatformCount++;
            }
            _isStartSpawn = true;
        }

        // генерация платформ по одной
        if (_isReadySpawn == true)
        {
            var obj = PoolManager.GetObject(platforms[Random.Range(0, platforms.Length)],
                new Vector3(0.0f, 0.0f, _platform.currentPositionPlatform), Quaternion.identity);
            obj.GetComponent<Platform>().SpawnObjectOnPlatform();
            MovePlatform(obj, duration, delay);
            _platform.currentPlatformCount++;
            _isReadySpawn = false;
        }
    }

    private void MovePlatform(GameObject obj, float duration, float delay)
    {
        obj.transform
            .DOMove(new Vector3(obj.transform.position.x, obj.transform.position.y,
            obj.transform.position.z - _platform.speedPlatform), duration)
            .SetEase(Ease.Linear)
            .SetDelay(delay)
            .SetLoops(-1, LoopType.Incremental);
    }

    private void DestroyPlatform()
    {
        if (_platform.currentPlatformCount == _platform.maxPlatformCount)
        {
            var platforms = Object.FindObjectsOfType<Platform>();

            for (int i = 0; i < platforms.Length; i++)
            {
                if (platforms[i].transform.position.z < _platform.destroyPositionPlatform && !BallBase.Instance.IsLaunch)
                {
                    if (platforms[i].transform.GetComponentsInChildren<BotBase>().Length > 0)
                    {
                        if (_platform.gameOver == true)
                        {
                            uiInterface.UiShowBall.HideSlider();
                            _timeGameOverUi.AddTimeRemaining();
                            uiInterface.UiGameScreen.ShowUI(true);

                            var bot = platforms[i].GetComponentsInChildren<BotBase>();
                            for (int j = 0; j < bot.Length; j++)
                            {
                                bot[j].AttackGun();
                            }

                            for (int k = 0; k < platforms.Length; k++)
                            {
                                platforms[k].gameObject.transform.DOKill();
                            }

                            uiInterface.UiGameScreen.GamePanel(false);
                            platforms[i].DestroyObjectOnPlatform();
                            _platform.currentPlatformCount = _platform.minPlatformCount;
                        }
                        else
                        {
                            //from debug
                            platforms[i].ReturnToPoolPlatform();
                            _platform.currentPlatformCount--;
                            _isReadySpawn = true;
                        }
                    }
                    else
                    {
                        platforms[i].ReturnToPoolPlatform();
                        _platform.currentPlatformCount--;
                        _isReadySpawn = true;
                    }
                }
            }
        }
    }

    private void DestroyAllPlatform()
    {
        var platforms = Object.FindObjectsOfType<Platform>();
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].ReturnToPoolPlatform();
            _platform.currentPlatformCount--;
        }

        _ball = Object.FindObjectOfType<BallBase>();

        if (_ball)
        {
            _ball.DestroyBall();

            if (_platform.nextLevel == true)
            {
                uiInterface.UiGameScreen.ShowUI(true);
                _timeNextLevelUi.AddTimeRemaining();
            }
        }

        _isStartSpawn = false;
    }

    private void ShowNextLevelUi()
    {
        uiInterface.UiGameScreen.LevelCompleted();
        _timeNextLevelUi.RemoveTimeRemaining();
    }

    private void ShowGameOverUi()
    {
        SaveData.SaveMaximumScore();
        SaveData.SaveCurrentScore();
        uiInterface.UiGameScreen.GameOver();
        _timeGameOverUi.RemoveTimeRemaining();
    }
}