using Scripts;
using UnityEngine;


// TEST
public sealed class AimSpawner : BaseModel
{
    [SerializeField] private Vector3[] _spawnPoints = null;

    private readonly string[] _aims = { "Tree_1", "Box_1" };

    private bool _isSpawn = false;
    private float _timeToSpawn = 5.0f;

    private TimeRemaining _timeSpawnAim;

    private void Start()
    {
        _timeSpawnAim = new TimeRemaining(ReadyToSpawnAim, _timeToSpawn);
    }

    private void ReadyToSpawnAim()
    {
        if (_isSpawn == true)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                if (GetRandom())
                {
                    var obj = PoolManager.GetObject(_aims[Random.Range(0, _aims.Length)],
                        _spawnPoints[i], Quaternion.identity);
                    AimManager.AddBotToList(obj.GetComponent<AimBase>());
                }
            }
            _isSpawn = false;
            _timeSpawnAim.RemoveTimeRemaining();
        }
    }

    private bool GetRandom()
    {
        int rnd = Random.Range(0, 3);

        if (rnd == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SpawnAim()
    {
        _isSpawn = true;
        _timeSpawnAim.AddTimeRemaining();
    }
}