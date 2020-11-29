using Scripts;
using UnityEngine;


public sealed class AimSpawner : BaseModel
{
    //данный класс не используется
    [SerializeField] private Vector3[] _spawnPoints = null;
    [SerializeField] private float _timeToSpawn = 0.0f;
    private bool _isSpawn = false;

    private readonly string[] _aims = { "Tree_1", "Tree_2", "Tree_3", "Tree_4", "Box_1" };
    private TimeRemaining _timeSpawnAim;

    protected override void Awake()
    {
        base.Awake();

        _timeSpawnAim = new TimeRemaining(ReadyToSpawnAim, _timeToSpawn);
    }

    private void ReadyToSpawnAim()
    {
        if (_isSpawn == true)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                if (Random.Range(0, 2) == 1)
                {
                    obj = PoolManager.GetObject(_aims[Random.Range(0, _aims.Length)],
                        _spawnPoints[i], Quaternion.identity);
                    //AimManager.AddAimToList(obj.GetComponent<AimBase>());
                }
            }
            _isSpawn = false;
            _timeSpawnAim.RemoveTimeRemaining();
        }
    }

    public void SpawnAim()
    {
        _isSpawn = true;
        _timeSpawnAim.AddTimeRemaining();
    }
}