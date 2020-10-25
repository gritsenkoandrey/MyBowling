using Scripts;
using UnityEngine;


public sealed class BotSpawner : BaseModel
{
    [SerializeField] private Vector3[] _spawnPoints = null;
    [SerializeField] private float _timeToSpawn = 5.0f;
    private bool _isSpawn = false;

    private readonly string[] _bots = { "Bot_cop", "Bot_cowboy" };
    private TimeRemaining _timeSpawnBot;

    private void Start()
    {
        _timeSpawnBot = new TimeRemaining(ReadyToSpawnBot, _timeToSpawn);
    }

    private void ReadyToSpawnBot()
    {
        if (_isSpawn == true)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                if (GetRandom())
                {
                    var obj = PoolManager.GetObject(_bots[Random.Range(0, _bots.Length)],
                        _spawnPoints[i], Quaternion.identity);
                    BotManager.AddBotToList(obj.GetComponent<BotBase>());
                }
            }
            _isSpawn = false;
            _timeSpawnBot.RemoveTimeRemaining();
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

    public void SpawnBot()
    {
        _isSpawn = true;
        _timeSpawnBot.AddTimeRemaining();
    }
}