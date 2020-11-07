using UnityEngine;


public sealed class PlatformController : BaseController, IExecute, IInitialization
{
    private readonly string[] _platforms = { "Big_Platform", "Medium_Platform", "Small_Platform" };
    private readonly float[] _spawnPlatformPositionZ = { 20.0f, 30.0f, 40.0f, 50.0f, 60.0f, 70.0f};

    private readonly byte _maxPlatformCount = 6;
    private readonly byte _minPlatformCount = 0;
    private byte _currentPlatformCount;

    private readonly float _destroyPlatformPositionZ = 0.0f;

    private bool _isReadySpawn = false;

    public void Initialization()
    {
        _currentPlatformCount = _minPlatformCount;
        _isReadySpawn = true;
    }

    public void Execute()
    {
        GeneratePlatform();
        DestroyPlatform();
    }

    private void DestroyPlatform()
    {
        if (_currentPlatformCount == _maxPlatformCount)
        {
            //todo сделать менеджер платформ
            var platforms = Object.FindObjectsOfType<Platform>();

            for (int i = 0; i < platforms.Length; i++)
            {
                if (platforms[i].transform.position.z < _destroyPlatformPositionZ)
                {
                    platforms[i].DestroyPlatform();
                    _currentPlatformCount--;
                    _isReadySpawn = true;
                }
            }
        }
    }

    private void GeneratePlatform()
    {
        if (_currentPlatformCount < _maxPlatformCount && _isReadySpawn == true)
        {
            for (int i = _currentPlatformCount; i < _maxPlatformCount; i++)
            {
                var obj = PoolManager.GetObject(_platforms[Random.Range(0, _platforms.Length)],
                    new Vector3(0.0f, 0.0f, _spawnPlatformPositionZ[i]), Quaternion.identity);
                obj.GetComponent<Platform>().SpawnObjectOnPlatform();
                obj.GetComponent<Platform>().MovePlatform();
                _currentPlatformCount++;
            }

            _isReadySpawn = false;
        }
    }
}