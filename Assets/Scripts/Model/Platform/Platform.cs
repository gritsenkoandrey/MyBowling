using UnityEngine;
using DG.Tweening;
using Scripts;


public sealed class Platform : BaseModel
{
    [SerializeField] private Transform[] _spawnPoint = null;
    [SerializeField] private BuildingParams _buildingParams = null;
    [SerializeField] private PlatformType _platformType = PlatformType.None;

    private readonly string[] _bots = { "Bot_Bartender", "Bot_Jester", "Bot_King", "Bot_Rider", "Bot_Soldier" };
    private readonly string[] _aims = { "Tree_1", "Tree_2", "Tree_3", "Tree_4", "Box_1", "Cart_01", "Cart_02" };
    private readonly string[] _buildings = { "House_01", "Tower_01", "Tower_02", "House_02", "House_03" };

    private TimeRemaining _timeRemainingMovePlatform;
    private readonly float _timeToMovePlatform = 1.5f;
    private readonly float _speedPlatform = 5.0f;

    protected override void Awake()
    {
        base.Awake();
        _timeRemainingMovePlatform = new TimeRemaining(Move, _timeToMovePlatform, true);
    }

    private void Move()
    {
        if (BallBase.IsLaunch == false)
        {
            transform
                .DOMove(new Vector3(
                    gameObject.transform.position.x,
                    gameObject.transform.position.y,
                    gameObject.transform.position.z - _speedPlatform), _buildingParams.Duration)
                .SetEase(_buildingParams.Ease);
        }
    }

    public void MovePlatform()
    {
        _timeRemainingMovePlatform.AddTimeRemaining();
    }

    public void DestroyPlatform()
    {
        var aim = GetComponentsInChildren<AimBase>();
        for (int i = 0; i < aim.Length; i++)
        {
            aim[i].DestroyAimWhenPlatformaDestroyed();
        }

        var building = GetComponentsInChildren<BuildingBase>();
        for (int i = 0; i < building.Length; i++)
        {
            building[i].DestroyBuildingWhenPlatformaDestroyed();
        }

        var bot = GetComponentsInChildren<BotBase>();
        for (int i = 0; i < bot.Length; i++)
        {
            bot[i].DestroyBotWhenPlatformaDestroyed();
        }

        gameObject.GetComponent<PoolObject>().ReturnToPool();

        _timeRemainingMovePlatform.RemoveTimeRemaining();
    }

    public void SpawnObjectOnPlatform()
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
            obj.transform.SetParent(gameObject.transform);
            BotManager.AddBotToList(obj.GetComponent<BotBase>());
        }
        else
        {
            obj = PoolManager.GetObject(_aims[Random.Range(0, _aims.Length)],
                spawnPoint.transform.position, Quaternion.identity);
            obj.transform.SetParent(gameObject.transform);
            AimManager.AddAimToList(obj.GetComponent<AimBase>());
        }
    }

    private void CreateOnBigSpawnPoint(Transform spawnPoint)
    {
        obj = PoolManager.GetObject(_buildings[Random.Range(0, _buildings.Length)],
            spawnPoint.transform.position, Quaternion.identity);
        obj.transform.SetParent(gameObject.transform);
    }
}