using Scripts;
using UnityEngine;


public sealed class PlatformSpawner : BaseModel
{
    private readonly string[] _platforms = { "Big_Platform", "Medium_Platform", "Small_Platform"};
    private readonly float[] _spawnPlatformPositionZ = { 0.0f, 10.0f, 20.0f };

    private readonly byte _maxPlatformCount = 3;
    private readonly byte _minPlatformCount = 0;
    private byte _currentPlatformCount;

    private bool _isReadySpawn = false;

    private TimeRemaining _timeRemainingReturnToPoolPlatform;
    private TimeRemaining _timeRemainingReturnToPollTarget;

    private readonly float _timeToReturnTopoolPlatform = 3.0f;
    private readonly float _timeToReturnToPoolTarget = 0.75f;

    protected override void Awake()
    {
        base.Awake();

        _currentPlatformCount = _minPlatformCount;
        _isReadySpawn = true;

        _timeRemainingReturnToPoolPlatform = new TimeRemaining(ReturnToPoolPlatform, _timeToReturnTopoolPlatform);
        _timeRemainingReturnToPollTarget = new TimeRemaining(ReturnToPoolTarget, _timeToReturnToPoolTarget);
    }

    public void Spawn()
    {
        GeneratePlatform();
        PreparingForRespawn();
    }

    private void GeneratePlatform()
    {
        if (_currentPlatformCount == 0 && _isReadySpawn == true)
        {
            for (int i = 0; i < _maxPlatformCount; i++)
            {
                obj = PoolManager.GetObject(_platforms[Random.Range(0, _platforms.Length)],
                    new Vector3(0.0f, 0.0f, _spawnPlatformPositionZ[i]), Quaternion.identity);
                obj.GetComponent<Platform>().SpawnTargetOnPlatform();
                _currentPlatformCount++;
            }

            _isReadySpawn = false;
        }
    }

    private void PreparingForRespawn()
    {
        if (_currentPlatformCount == _maxPlatformCount && BotManager.BotDestroyed() && _isReadySpawn == false)
        {
            _timeRemainingReturnToPollTarget.AddTimeRemaining();
            _timeRemainingReturnToPoolPlatform.AddTimeRemaining();
        }
    }

    private void ReturnToPoolPlatform()
    {
        var platform = FindObjectsOfType<Platform>();
        for (int i = 0; i < platform.Length; i++)
        {
            platform[i].GetComponent<PoolObject>().ReturnToPool();
            _currentPlatformCount--;
        }

        _timeRemainingReturnToPoolPlatform.RemoveTimeRemaining();
    }

    private void ReturnToPoolTarget()
    {
        if (!_isReadySpawn)
        {
            var aim = FindObjectsOfType<AimBase>();
            for (int i = 0; i < aim.Length; i++)
            {
                aim[i].DestroyAimWhenLevelClean();
            }

            var building = FindObjectsOfType<BuildingBase>();
            for (int i = 0; i < building.Length; i++)
            {
                building[i].DestroyBuildingWhenLevelClean();
            }

            _isReadySpawn = true;
            _timeRemainingReturnToPollTarget.RemoveTimeRemaining();
        }
    }
}