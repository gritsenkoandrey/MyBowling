using UnityEngine;
using DG.Tweening;
using Scripts;


public sealed class Platform : BaseModel
{
    [SerializeField] private Transform[] _smallSpawnPoint = null;
    [SerializeField] private Transform[] _midlSpawnPoint = null;
    [SerializeField] private Transform[] _bigSpawnPoint = null;
    [SerializeField] private Transform[] _longSpawnPoint = null;
    [SerializeField] private Transform[] _botSpawnPoint = null;

    private readonly string[] _smallPrefab = { "Small_01", "Small_02", "Small_03", "Small_04", "Small_05", "Small_06", "Small_07", "Small_08", "Small_09", "Small_10", "Small_11", "Small_12", "Small_13", "Small_14", "Small_15", "Small_16" };
    private readonly string[] _midlePrefab = { "Midle_01", "Midle_02", "Midle_03", "Midle_04", "Midle_05", "Midle_06", "Midle_07", "Midle_08", "Midle_09", "Midle_10" };
    private readonly string[] _longPrefab = { "Long_01", "Long_02", "Long_03", "Long_04", "Long_05" };
    private readonly string[] _bigPrefab = { "Big_01", "Big_02", "Big_03", "Big_04", "Big_05", "Big_06" };
    private readonly string[] _botPrefab = { "Bot_Bartender", "Bot_Jester", "Bot_King", "Bot_Rider", "Bot_Soldier", "Bot_Mage" };

    [SerializeField] private BuildingParams _buildingParams = null;

    private TimeRemaining _timeRemainingMovePlatform;
    [SerializeField] private float _timeToMovePlatform = 0.0f;
    private readonly float _speedPlatform = 5.0f;

    protected override void Awake()
    {
        base.Awake();
        _timeRemainingMovePlatform = new TimeRemaining(Move, _timeToMovePlatform, true);
    }

    private void Move()
    {
        transform
            .DOMove(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,
            gameObject.transform.position.z - _speedPlatform), _buildingParams.Duration)
            .SetEase(_buildingParams.Ease)
            .SetDelay(_buildingParams.Delay);
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
            aim[i].DestroyAimWhenPlatformDestroyed();
        }

        var building = GetComponentsInChildren<BuildingBase>();
        for (int i = 0; i < building.Length; i++)
        {
            building[i].DestroyBuildingWhenPlatformDestroyed();
        }

        var bot = GetComponentsInChildren<BotBase>();
        for (int i = 0; i < bot.Length; i++)
        {
            bot[i].DestroyBotWhenPlatformDestroyed();
        }

        _timeRemainingMovePlatform.RemoveTimeRemaining();
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }

    public void SpawnObjectOnPlatform()
    {
        CreatePrefabOnSpawnPoint(_botSpawnPoint, _botPrefab);
        CreatePrefabOnSpawnPoint(_smallSpawnPoint, _smallPrefab);
        CreatePrefabOnSpawnPoint(_midlSpawnPoint, _midlePrefab);
        CreatePrefabOnSpawnPoint(_longSpawnPoint, _longPrefab);
        CreatePrefabOnSpawnPoint(_bigSpawnPoint, _bigPrefab);
    }

    private void CreatePrefabOnSpawnPoint(Transform[] spawnPoint, string[] prefabs)
    {
        if (spawnPoint.Length > 0)
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                obj = PoolManager.GetObject(prefabs[Random.Range(0, prefabs.Length)],
                    spawnPoint[i].transform.position, Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
            }
        }
    }
}