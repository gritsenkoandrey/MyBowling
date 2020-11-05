using UnityEngine;


public sealed class Platform : BaseModel
{
    [SerializeField] private Transform[] _spawnPoint = null;
    [SerializeField] private PlatformType _platformType = PlatformType.None;

    //private readonly string[] _bots = { "Bot_cop", "Bot_cowboy", "Bot_Bean_Female", "Bot_Bean_Town_Female" };
    private readonly string[] _bots = { "Bot_Bartender", "Bot_Jester", "Bot_King", "Bot_Rider", "Bot_Soldier" };
    private readonly string[] _aims = { "Tree_1", "Tree_2", "Tree_3", "Tree_4", "Box_1" };
    private readonly string[] _buildings = { "House_01", "Tower_01", "Tower_02" };

    public void SpawnTargetOnPlatform()
    {
        if (_platformType == PlatformType.Big)
        {
            CreateOnBigSpawnPoint(_spawnPoint[0]);
            CreateOnBigSpawnPoint(_spawnPoint[1]);

            for (int i = 2; i < _spawnPoint.Length; i++)
            {
                CreateOnSmallSpawnPoint(_spawnPoint[i]);
            }
        }

        if (_platformType == PlatformType.Medium)
        {
            CreateOnBigSpawnPoint(_spawnPoint[0]);

            for (int i = 1; i < _spawnPoint.Length; i++)
            {
                CreateOnSmallSpawnPoint(_spawnPoint[i]);
            }
        }

        if (_platformType == PlatformType.Small)
        {
            for (int i = 0; i < _spawnPoint.Length; i++)
            {
                CreateOnSmallSpawnPoint(_spawnPoint[i]);
            }
        }
    }

    private void CreateOnSmallSpawnPoint(Transform spawnPoint)
    {
        if (Random.Range(0, 2) == 1)
        {
            obj = PoolManager.GetObject(_bots[Random.Range(0, _bots.Length)],
                spawnPoint.transform.position, Quaternion.identity);
            BotManager.AddBotToList(obj.GetComponent<BotBase>());
        }
        else
        {
            obj = PoolManager.GetObject(_aims[Random.Range(0, _aims.Length)],
                spawnPoint.transform.position, Quaternion.identity);
            AimManager.AddAimToList(obj.GetComponent<AimBase>());
        }
    }

    private void CreateOnBigSpawnPoint(Transform spawnPoint)
    {
        if (Random.Range(0, 2) == 1)
        {
            obj = PoolManager.GetObject(_buildings[Random.Range(0, _buildings.Length)],
                spawnPoint.transform.position, Quaternion.identity);
        }
    }
}