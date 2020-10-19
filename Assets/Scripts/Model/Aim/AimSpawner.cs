using Scripts;
using UnityEngine;


// TEST
public sealed class AimSpawner : BaseModel
{
    [SerializeField] private Vector3[] _spawnPoints = null;

    private readonly string[] _aims = { "Tree_1", "Box_1" };

    private bool _isSpawn = false;
    private float _timeToSpawn = 3.0f;
    private int _aimsCount = 0;

    private TimeRemaining _timeSpawnAim;

    private void Start()
    {
        _timeSpawnAim = new TimeRemaining(SpawnAim, _timeToSpawn);
    }

    private void Update()
    {
        _aimsCount = FindObjectsOfType<AimBase>().Length;

        if (_aimsCount == 0)
        {
            _isSpawn = true;
        }

        if (_isSpawn == true)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                if(GetRandomResult())
                {
                    prefabOne = PoolManager.GetObject(_aims[Random.Range(0, _aims.Length)],
                        _spawnPoints[i], Quaternion.identity);
                }
            }
            _isSpawn = false;
        }
    }

    private void SpawnAim()
    {
        prefabOne = PoolManager.GetObject(_aims[Random.Range(0, _aims.Length)],
            _spawnPoints[Random.Range(0, _spawnPoints.Length)], Quaternion.identity);
        _isSpawn = false;
        _timeSpawnAim.RemoveTimeRemaining();
    }

    private bool GetRandomResult()
    {
        int rnd = Random.Range(0, 2);

        if (rnd == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}