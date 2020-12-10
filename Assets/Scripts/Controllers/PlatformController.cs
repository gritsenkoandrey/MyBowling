using DG.Tweening;
using Scripts;
using UnityEngine;


public sealed class PlatformController : BaseController, IExecute, IInitialization
{
    private GameLevelInfo _score;
    private PlatformInfo _platform;

    private bool _isReadySpawn;
    private bool _isStartSpawn;

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

    public void Initialization()
    {
        _score = Data.Instance.GameLevelData.GetGameLevelInfo(GameLevelType.Test);
        _platform = Data.Instance.PlatformData.GetPlatformInfo(PlatformType.Standart);

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
        if (ScoreController.CountScore < _score.levelTwoScore)
        {
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelOne, _platform.duration, _platform.delay);
        }

        if (ScoreController.CountScore >= _score.levelTwoScore)
        {
            if (_isLevelPassedOne == false)
            {
                _isLevelPassedOne = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelTwo, _platform.duration, _platform.delay);
        }

        if (ScoreController.CountScore >= _score.levelThreeScore)
        {
            if (_isLevelPassedTwo == false)
            {
                _isLevelPassedTwo = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelThree, _platform.duration, _platform.delay);
        }

        if (ScoreController.CountScore >= _score.levelFourScore)
        {
            if (_isLevelPassedThree == false)
            {
                _isLevelPassedThree = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelFour, _platform.duration, _platform.delay);
        }

        if (ScoreController.CountScore >= _score.levelFiveScore)
        {
            if (_isLevelPassedFour == false)
            {
                _isLevelPassedFour = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelFive, _platform.duration, _platform.delay);
        }

        if (ScoreController.CountScore >= _score.levelSixScore)
        {
            if (_isLevelPassedFive == false)
            {
                _isLevelPassedFive = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelOne, _platform.duration, _platform.delay);
        }

        if (ScoreController.CountScore >= _score.levelSevenScore)
        {
            if (_isLevelPassedSix == false)
            {
                _isLevelPassedSix = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelTwo, _platform.duration, _platform.delay);
        }

        if (ScoreController.CountScore >= _score.levelEightScore)
        {
            if (_isLevelPassedSeven == false)
            {
                _isLevelPassedSeven = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelTwo, _platform.duration, _platform.delay);
        }

        if (ScoreController.CountScore >= _score.levelNineScore)
        {
            if (_isLevelPassedEight == false)
            {
                _isLevelPassedEight = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelThree, _platform.duration, _platform.delay);
        }

        if (ScoreController.CountScore >= _score.levelTenScore)
        {
            if (_isLevelPassedNine == false)
            {
                _isLevelPassedNine = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelFour, _platform.duration, _platform.delay);
        }

        if (ScoreController.CountScore >= _score.levelTenScore * 2)
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
        // генерация платформ, когда поле пустое или все платформы уничтожены
        if (_isStartSpawn == false)
        {
            for (int i = _platform.currentPlatformCount; i < _platform.maxPlatformCount; i++)
            {
                var obj = PoolManager.GetObject(Data.Instance.PrefabsData
                    .platformsLevelOne[Random.Range(0, Data.Instance.PrefabsData
                    .platformsLevelOne.Length)], new Vector3(0.0f, 0.0f, _platform.startPositionPlatforms[i]), Quaternion.identity);
                obj.GetComponent<Platform>().SpawnObjectOnPlatform();
                MovePlatform(obj, duration, delay);
                _platform.currentPlatformCount++;
            }
            _isStartSpawn = true;
        }
        // генерация платформ по одной
        if (_isReadySpawn == true)
        {
            for (int i = _platform.currentPlatformCount; i < _platform.maxPlatformCount; i++)
            {
                var obj = PoolManager.GetObject(platforms[Random.Range(0, platforms.Length)],
                    new Vector3(0.0f, 0.0f, _platform.currentPositionPlatform), Quaternion.identity);
                obj.GetComponent<Platform>().SpawnObjectOnPlatform();
                MovePlatform(obj, duration, delay);
                _platform.currentPlatformCount++;
            }
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
                        //for GD
                        if (_platform.gameOver == true)
                        {
                            uiInterface.UiGameScreen.GameOver();
                        }
                    }
                    platforms[i].ReturnToPoolPlatform();
                    _platform.currentPlatformCount--;
                    _isReadySpawn = true;
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
        _isStartSpawn = false;
        //for GD
        if (_platform.nextLevel == true)
        {
            uiInterface.UiGameScreen.NextLevel();
        }
    }
}