using Scripts;
using UnityEngine;


public sealed class PlatformModel : MonoBehaviour
{
    [SerializeField] private Platform _bigPlatform = null;
    [SerializeField] private Platform _mediumPlatform = null;
    [SerializeField] private Platform _smallPlatform = null;

    private readonly float[] _spawnPlatformPointPosZ = { 0.0f, 10.0f, 20.0f };

    private readonly byte _maxPlatformCount = 3;
    private readonly byte _minPlatformCount = 0;
    private byte _currentPlatformCount = 0;

    private bool _isReadySpawn = false;

    private TimeRemaining _timeRemaining;
    private readonly float _timeToReadySpawn = 5.0f;

    private void Start()
    {
        _isReadySpawn = true;

        _timeRemaining = new TimeRemaining(ReadyToSpawn, _timeToReadySpawn);
    }

    private void Update()
    {
        GeneratePlatform();
        _timeRemaining.AddTimeRemaining();
    }

    private void GeneratePlatform()
    {

        if (_currentPlatformCount == 0 && _isReadySpawn == true)
        {
            for (int i = 0; i < _maxPlatformCount; i++)
            {
                var platform = Instantiate(SetRandomPlatform(),
                    new Vector3(0.0f, 0.0f, _spawnPlatformPointPosZ[i]), Quaternion.identity);
                platform.SpawnTargetOnPlatform();
            }

            _currentPlatformCount = _maxPlatformCount;
            _isReadySpawn = false;
        }
    }

    private Platform SetRandomPlatform()
    {
        var rnd = Random.Range(0, _maxPlatformCount);

        if (rnd == 0)
        {
            return _bigPlatform;
        }
        else if (rnd == 1)
        {
            return _mediumPlatform;
        }
        else
        {
            return _smallPlatform;
        }
    }

    private void ReadyToSpawn()
    {
        if (_currentPlatformCount == _maxPlatformCount /*&& AimManager.AimDestroyed()*/ && BotManager.BotDestroyed())
        {
            var platform = FindObjectsOfType<Platform>();
            for (int i = 0; i < platform.Length; i++)
            {
                Destroy(platform[i].gameObject);
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

            _currentPlatformCount = _minPlatformCount;
            _isReadySpawn = true;
        }

        _timeRemaining.RemoveTimeRemaining();
    }
}