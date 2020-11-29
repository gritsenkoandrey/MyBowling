using Scripts;
using UnityEngine;


public sealed class PlatformController : BaseController, IExecute, IInitialization
{
    private readonly string[] _platformsLevelOne = { "Platform_01", "Platform_02", "Platform_03", "Platform_04", "Platform_05" };
    private readonly string[] _platformsLevelTwo = { "Platform_01", "Platform_02", "Platform_03", "Platform_04", "Platform_05", "Platform_lvl2_01", "Platform_lvl2_02", "Platform_lvl2_03" };
    private readonly string[] _platformsLevelThree = { "Platform_03", "Platform_05", "Platform_lvl2_01", "Platform_lvl2_02", "Platform_lvl2_03", "Platform_lvl3_01", "Platform_lvl3_02", "Platform_lvl3_03" };
    private readonly string[] _platformsLevelFour = { "Platform_lvl2_01", "Platform_lvl2_03", "Platform_lvl3_01", "Platform_lvl3_02", "Platform_lvl3_03", "Platform_lvl4_01", "Platform_lvl4_02", "Platform_lvl4_03" };
    private readonly string[] _platformLevelFive = { "Platform_lvl3_01", "Platform_lvl3_02", "Platform_lvl3_03", "Platform_lvl4_01", "Platform_lvl4_02", "Platform_lvl4_03", "Platform_lvl5_01", "Platform_lvl5_02" };

    private readonly float[] _startSpawnPlatformsPos = { 20.0f, 30.0f, 40.0f, 50.0f, 60.0f, 70.0f};
    private readonly float _spawnPlatformPos = 40.0f;

    private readonly byte _maxPlatformCount = 6;
    private readonly byte _minPlatformCount = 0;
    private byte _currentPlatformCount;

    private readonly float _destroyPlatformPositionZ = -10.0f;

    private bool _isReadySpawn = false;
    private bool _isStartSpawn = false;

    private TimeRemaining _timeRemainingReadySpawn;
    private readonly float _timeReadySpawn = 2.0f;

    public void Initialization()
    {
        _currentPlatformCount = _minPlatformCount;
        _isReadySpawn = true;

        _timeRemainingReadySpawn = new TimeRemaining(ReadyToSpawn, _timeReadySpawn);
    }

    public void Execute()
    {
        StartSpawnPlatforms();
        NextSpawnPlatforms();
        DestroyPlatform();
    }

    private void StartSpawnPlatforms()
    {
        if (_isStartSpawn == false)
        {
            for (int i = _currentPlatformCount; i < _maxPlatformCount; i++)
            {
                var obj = PoolManager.GetObject(_platformsLevelOne[Random.Range(0, _platformsLevelOne.Length)], new Vector3(0.0f, 0.0f, _startSpawnPlatformsPos[i]), Quaternion.identity);
                obj.GetComponent<Platform>().SpawnObjectOnPlatform();
                obj.GetComponent<Platform>().MovePlatform();
                _currentPlatformCount++;
            }

            _isReadySpawn = false;
            _isStartSpawn = true;
        }
    }

    private void NextSpawnPlatforms()
    {
        if (_currentPlatformCount < _maxPlatformCount && _isReadySpawn == true)
        {
            if (ScoreController.CountScore < Data.Instance.GameLevelData.leveTwoScore)
            {
                GeneratePlatform(_platformsLevelOne);
            }
            if (ScoreController.CountScore >= Data.Instance.GameLevelData.leveTwoScore)
            {
                GeneratePlatform(_platformsLevelTwo);
            }
            if (ScoreController.CountScore >= Data.Instance.GameLevelData.leveThreeScore)
            {
                GeneratePlatform(_platformsLevelThree);
            }
            if (ScoreController.CountScore >= Data.Instance.GameLevelData.levelFourScore)
            {
                GeneratePlatform(_platformsLevelFour);
            }
            if (ScoreController.CountScore >= Data.Instance.GameLevelData.levelFiveScore)
            {
                GeneratePlatform(_platformLevelFive);
            }
        }
    }

    private void GeneratePlatform(string[] platforms)
    {
        if (_isStartSpawn == true)
        {
            for (int i = _currentPlatformCount; i < _maxPlatformCount; i++)
            {
                var obj = PoolManager.GetObject(platforms[Random.Range(0, platforms.Length)],
                    new Vector3(0.0f, 0.0f, _spawnPlatformPos), Quaternion.identity);
                obj.GetComponent<Platform>().SpawnObjectOnPlatform();
                obj.GetComponent<Platform>().MovePlatform();
                _currentPlatformCount++;
            }
            _isReadySpawn = false;
        }
    }

    private void DestroyPlatform()
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

                    platforms[i].DestroyPlatform();
                    _currentPlatformCount--;
                    _timeRemainingReadySpawn.AddTimeRemaining();
                }
            }
        }
    }

    private void ReadyToSpawn()
    {
        _isReadySpawn = true;
        _timeRemainingReadySpawn.RemoveTimeRemaining();
    }
}