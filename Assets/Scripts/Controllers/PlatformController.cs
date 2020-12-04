using DG.Tweening;
using Scripts;
using UnityEngine;


public sealed class PlatformController : BaseController, IExecute, IInitialization
{
    private readonly float[] _startSpawnPlatformsPos = { 20.0f, 30.0f, 40.0f, 50.0f, 60.0f, 70.0f};
    private readonly float _spawnPlatformPos = 40.0f;

    private readonly byte _maxPlatformCount = 6;
    private readonly byte _minPlatformCount = 0;
    private byte _currentPlatformCount;

    private readonly float _speedPlatform = 5.0f;
    private readonly float _delay = 2.0f;
    private float _duration = 1.5f;

    private readonly float _destroyPlatformPositionZ = -10.0f;

    private bool _isReadySpawn;
    private bool _isStartSpawn;

    private bool _isLevelPassedOne;
    private bool _isLevelPassedTwo;
    private bool _isLevelPassedThree;
    private bool _isLevelPassedFour;

    public void Initialization()
    {
        _currentPlatformCount = _minPlatformCount;

        _isReadySpawn = false;
        _isStartSpawn = false;

        _isLevelPassedOne = false;
        _isLevelPassedTwo = false;
        _isLevelPassedThree = false;
        _isLevelPassedFour = false;
    }

    public void Execute()
    {
        SpawnPlatform();
        DestroyCurrentPlatform();
    }

    private void SpawnPlatform()
    {
        if (ScoreController.CountScore < Data.Instance.GameLevelData.leveTwoScore)
        {
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelOne, _duration);
        }

        if (ScoreController.CountScore >= Data.Instance.GameLevelData.leveTwoScore)
        {
            if (_isLevelPassedOne == false)
            {
                _isLevelPassedOne = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelTwo, _duration);
        }

        if (ScoreController.CountScore >= Data.Instance.GameLevelData.leveThreeScore)
        {
            if (_isLevelPassedTwo == false)
            {
                _isLevelPassedTwo = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelThree, _duration);
        }

        if (ScoreController.CountScore >= Data.Instance.GameLevelData.levelFourScore)
        {
            if (_isLevelPassedThree == false)
            {
                _isLevelPassedThree = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelFour, _duration);
        }

        if (ScoreController.CountScore >= Data.Instance.GameLevelData.levelFiveScore)
        {
            if (_isLevelPassedFour == false)
            {
                _isLevelPassedFour = true;
                DestroyAllPlatform();
            }
            GeneratePlatform(Data.Instance.PrefabsData.platformsLevelFive, _duration);
        }
    }

    private void GeneratePlatform(string[] platforms, float duration)
    {
        if (_isStartSpawn == false)
        {
            for (int i = _currentPlatformCount; i < _maxPlatformCount; i++)
            {
                var obj = PoolManager.GetObject(Data.Instance.PrefabsData
                    .platformsLevelOne[Random.Range(0, Data.Instance.PrefabsData
                    .platformsLevelOne.Length)], new Vector3(0.0f, 0.0f, _startSpawnPlatformsPos[i]), Quaternion.identity);
                obj.GetComponent<Platform>().SpawnObjectOnPlatform();
                MovePlatform(obj, duration);
                _currentPlatformCount++;
            }
            _isStartSpawn = true;
        }

        if (_isReadySpawn == true)
        {
            for (int i = _currentPlatformCount; i < _maxPlatformCount; i++)
            {
                var obj = PoolManager.GetObject(platforms[Random.Range(0, platforms.Length)],
                    new Vector3(0.0f, 0.0f, _spawnPlatformPos), Quaternion.identity);
                obj.GetComponent<Platform>().SpawnObjectOnPlatform();
                MovePlatform(obj, duration);
                _currentPlatformCount++;
            }
            _isReadySpawn = false;
        }
    }

    private void MovePlatform(GameObject obj, float duration)
    {
        obj.transform
            .DOMove(new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - _speedPlatform), duration)
            .SetEase(Ease.Linear)
            .SetDelay(_delay)
            .SetLoops(-1, LoopType.Incremental);
    }

    private void DestroyCurrentPlatform()
    {
        if (_currentPlatformCount == _maxPlatformCount)
        {
            var platforms = Object.FindObjectsOfType<Platform>();

            for (int i = 0; i < platforms.Length; i++)
            {
                if (platforms[i].transform.position.z < _destroyPlatformPositionZ)
                {
                    if (platforms[i].transform.GetComponentsInChildren<BotBase>().Length > 0)
                    {
                        uiInterface.UiGameScreen.GameOver();
                    }
                    platforms[i].ReturnToPoolPlatform();
                    _currentPlatformCount--;
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
            _currentPlatformCount--;
        }
        _isStartSpawn = false;
    }
}