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

    //todo пересмотреть
    private bool _isLevelPassedOne;
    private bool _isLevelPassedTwo;
    private bool _isLevelPassedThree;
    private bool _isLevelPassedFour;
    private bool _isLevelPassedFive;
    private bool _isLevelPassedSix;
    private bool _isLevelPassedSeven;
    private bool _isLevelPassedEight;
    private bool _isLevelPassedNine;
    private bool _isLevelPassedTen;

    public PlatformController()
    {
        _score = Data.Instance.GameLevelData.GetGameLevelInfo(GameLevelType.Test);
        _platform = Data.Instance.PlatformData.GetPlatformInfo(PlatformType.Standart);

        _timeNextLevelUi = new TimeRemaining(ShowNextLevelUi, _timeToShowNextLevelUi);
        _timeGameOverUi = new TimeRemaining(ShowGameOverUi, _timeToShowGameOverUi);

        _isReadySpawn = false;
        _isStartSpawn = false;
    }

    public void Execute()
    {
        SpawnPlatform();
        DestroyPlatform();
    }

    // todo пересмотреть метод генерации платформ в зависимости от уровня
    private void SpawnPlatform()
    {
        if (LevelController.CountScore < _score.levelTwoScore)
        {
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelOne, _platform.duration, _platform.delay);
        }

        if (LevelController.CountScore >= _score.levelTwoScore)
        {
            if (_isLevelPassedOne == false)
            {
                _isLevelPassedOne = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelTwo, _platform.duration, _platform.delay);
        }

        if (LevelController.CountScore >= _score.levelThreeScore)
        {
            if (_isLevelPassedTwo == false)
            {
                _isLevelPassedTwo = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelThree, _platform.duration, _platform.delay);
        }

        if (LevelController.CountScore >= _score.levelFourScore)
        {
            if (_isLevelPassedThree == false)
            {
                _isLevelPassedThree = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelFour, _platform.duration, _platform.delay);
        }

        if (LevelController.CountScore >= _score.levelFiveScore)
        {
            if (_isLevelPassedFour == false)
            {
                _isLevelPassedFour = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelFive, _platform.duration, _platform.delay);
        }

        if (LevelController.CountScore >= _score.levelSixScore)
        {
            if (_isLevelPassedFive == false)
            {
                _isLevelPassedFive = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelOne, _platform.duration, _platform.delay);
        }

        if (LevelController.CountScore >= _score.levelSevenScore)
        {
            if (_isLevelPassedSix == false)
            {
                _isLevelPassedSix = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelTwo, _platform.duration, _platform.delay);
        }

        if (LevelController.CountScore >= _score.levelEightScore)
        {
            if (_isLevelPassedSeven == false)
            {
                _isLevelPassedSeven = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelTwo, _platform.duration, _platform.delay);
        }

        if (LevelController.CountScore >= _score.levelNineScore)
        {
            if (_isLevelPassedEight == false)
            {
                _isLevelPassedEight = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelThree, _platform.duration, _platform.delay);
        }

        if (LevelController.CountScore >= _score.levelTenScore)
        {
            if (_isLevelPassedNine == false)
            {
                _isLevelPassedNine = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelFour, _platform.duration, _platform.delay);
        }

        if (LevelController.CountScore >= _score.levelTenScore * 2)
        {
            if (_isLevelPassedTen == false)
            {
                _isLevelPassedTen = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelFive, _platform.duration, _platform.delay);
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
                if (platforms[i].transform.position.z < _platform.destroyPositionPlatform)
                {
                    if (platforms[i].transform.GetComponentsInChildren<BotBase>().Length > 0)
                    {
                        if (_platform.gameOver == true)
                        {
                            _timeGameOverUi.AddTimeRemaining();
                            uiInterface.UiGameScreen.isShowUI = true;

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
                uiInterface.UiGameScreen.isShowUI = true;
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
        uiInterface.UiGameScreen.GameOver();
        _timeGameOverUi.RemoveTimeRemaining();
    }
}