using Scripts;
using UnityEngine;


public sealed class BotSpawner : BaseModel
{
    [SerializeField] private Vector3[] _spawnPoints = null;
    [SerializeField] private float _timeToSpawn = 0.0f;
    private bool _isSpawn = false;

    private readonly string[] _bots = { "Bot_cop", "Bot_cowboy", "Bot_Bean_Female", "Bot_Bean_Town_Female" };

    private TimeRemaining _timeSpawnBot;

    protected override void Awake()
    {
        base.Awake();

        _timeSpawnBot = new TimeRemaining(ReadyToSpawnBot, _timeToSpawn);
    }

    private void ReadyToSpawnBot()
    {
        if (_isSpawn == true)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                if (Random.Range(0, 2) == 1)
                {
                    obj = PoolManager.GetObject(_bots[Random.Range(0, _bots.Length)],
                        _spawnPoints[i], Quaternion.identity);
                    BotManager.AddBotToList(obj.GetComponent<BotBase>());
                }
            }
            _isSpawn = false;
            _timeSpawnBot.RemoveTimeRemaining();
        }
    }

    public void SpawnBot()
    {
        _isSpawn = true;
        _timeSpawnBot.AddTimeRemaining();
    }
}