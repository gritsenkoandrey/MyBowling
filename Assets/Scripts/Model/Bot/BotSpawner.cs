using Scripts;
using UnityEngine;


// TEST
public sealed class BotSpawner : BaseModel
{
    [SerializeField] private Vector3[] _spawnPoints = null;

    private readonly string[] _bots = { "Bot_cop", "Bot_cowboy" };

    private bool _isSpawn = false;
    private float _timeToSpawn = 5.0f;
    private int _botsCount = 0;

    private TimeRemaining _timeSpawnBot;

    private void Start()
    {
        _timeSpawnBot = new TimeRemaining(SpawnBot, _timeToSpawn);
    }

    private void Update()
    {
        _botsCount = FindObjectsOfType<BotBase>().Length;

        if (_botsCount == 0)
        {
            _isSpawn = true;
        }

        if (_isSpawn == true)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                if (GetRandomResult())
                {
                    prefabOne = PoolManager.GetObject(_bots[Random.Range(0, _bots.Length)],
                        _spawnPoints[i], Quaternion.identity);
                }
            }
            _isSpawn = false;
        }
    }

    private void SpawnBot()
    {
        prefabOne = PoolManager.GetObject(_bots[Random.Range(0, _bots.Length)],
            _spawnPoints[Random.Range(0, _spawnPoints.Length)], Quaternion.identity);
        _isSpawn = false;
        _timeSpawnBot.RemoveTimeRemaining();
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