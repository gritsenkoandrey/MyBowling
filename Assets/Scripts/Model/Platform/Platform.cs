using Scripts;
using UnityEngine;
using DG.Tweening;


public sealed class Platform : BaseModel
{
    [SerializeField] private Transform[] _smallSpawnPoint = null;
    [SerializeField] private Transform[] _midleSpawnPoint = null;
    [SerializeField] private Transform[] _bigSpawnPoint = null;
    [SerializeField] private Transform[] _longSpawnPoint = null;
    [SerializeField] private Transform[] _botSpawnPoint = null;

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

    public void ReturnToPoolPlatform()
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
        CreatePrefabOnSpawnPoint(_botSpawnPoint, Data.Instance.PrefabsData.botPrefab);
        CreatePrefabOnSpawnPoint(_smallSpawnPoint, Data.Instance.PrefabsData.smallPrefab);
        CreatePrefabOnSpawnPoint(_midleSpawnPoint, Data.Instance.PrefabsData.midlePrefab);
        CreatePrefabOnSpawnPoint(_longSpawnPoint, Data.Instance.PrefabsData.longPrefab);
        CreatePrefabOnSpawnPoint(_bigSpawnPoint, Data.Instance.PrefabsData.bigPrefab);
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