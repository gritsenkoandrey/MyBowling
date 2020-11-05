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

    private TimeRemaining _timeRemainingReadySpawn;
    private readonly float _timeToReadySpawn = 3.0f;

    protected override void Awake()
    {
        base.Awake();

        _currentPlatformCount = 0;
        _isReadySpawn = true;
        _timeRemainingReadySpawn = new TimeRemaining(ReloadSpawn, _timeToReadySpawn);
    }

    public void Spawn()
    {
        GeneratePlatform();
        PrepareForNewSpawn();
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
            }

            _currentPlatformCount = _maxPlatformCount;
            _isReadySpawn = false;
        }
    }

    private void PrepareForNewSpawn()
    {
        if (_currentPlatformCount == _maxPlatformCount && BotManager.BotDestroyed())
        {
            _timeRemainingReadySpawn.AddTimeRemaining();
        }
    }

    private void ReloadSpawn()
    {
        _currentPlatformCount = _minPlatformCount;
        _isReadySpawn = true;
        ReturnToPool();
        _timeRemainingReadySpawn.RemoveTimeRemaining();
    }

    private void ReturnToPool()
    {
        var platform = FindObjectsOfType<Platform>();
        for (int i = 0; i < platform.Length; i++)
        {
            platform[i].GetComponent<PoolObject>().ReturnToPool();
        }

        var aim = FindObjectsOfType<AimBase>();
        for (int i = 0; i < aim.Length; i++)
        {
            aim[i].GetComponent<PoolObject>().ReturnToPool();
        }

        var building = FindObjectsOfType<BuildingBase>();
        for (int i = 0; i < building.Length; i++)
        {
            building[i].GetComponent<PoolObject>().ReturnToPool();
        }
    }
}