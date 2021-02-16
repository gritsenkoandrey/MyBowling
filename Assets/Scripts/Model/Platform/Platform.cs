using Scripts;
using UnityEngine;
using DG.Tweening;


public sealed class Platform : BasePlatform
{
    [SerializeField] private Transform[] _smallSpawnPoint = null;
    [SerializeField] private Transform[] _midleSpawnPoint = null;
    [SerializeField] private Transform[] _bigSpawnPoint = null;
    [SerializeField] private Transform[] _longSpawnPoint = null;
    [SerializeField] private Transform[] _botSpawnPoint = null;

    private GameLevelInfo _score;

    protected override void Awake()
    {
        base.Awake();

        _score = Data.Instance.GameLevelData.GetGameLevelInfo(GameLevelType.Test);
    }

    //from debug
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

        var bomb = GetComponentsInChildren<BombBase>();
        for (int i = 0; i < bomb.Length; i++)
        {
            bomb[i].DestroyBombWhenPlatformDestroyed();
        }

        gameObject.transform.DOKill();
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }

    public void DestroyObjectOnPlatform()
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

        var bomb = GetComponentsInChildren<BombBase>();
        for (int i = 0; i < bomb.Length; i++)
        {
            bomb[i].DestroyBombWhenPlatformDestroyed();
        }
    }

    public void SpawnObjectOnPlatform()
    {
        if (LevelController.CountScore < _score.levelFiveScore)
        {
            CreatePrefabOnSpawnPoint(_botSpawnPoint, Data.Instance.PrefabsData.botPrefab);
            CreatePrefabOnSpawnPoint(_smallSpawnPoint, Data.Instance.PrefabsData.smallPrefab);
            CreatePrefabOnSpawnPoint(_midleSpawnPoint, Data.Instance.PrefabsData.midlePrefab);
            CreatePrefabOnSpawnPoint(_longSpawnPoint, Data.Instance.PrefabsData.longPrefab);
            CreatePrefabOnSpawnPoint(_bigSpawnPoint, Data.Instance.PrefabsData.bigPrefab);
        }

        if (LevelController.CountScore >= _score.levelFiveScore && LevelController.CountScore < _score.levelSevenScore)
        {
            CreatePrefabOnSpawnPoint(_smallSpawnPoint, Data.Instance.PrefabsData.smallPrefab);
            CreatePrefabOnSpawnPoint(_midleSpawnPoint, Data.Instance.PrefabsData.midlePrefab);
            CreatePrefabOnSpawnPoint(_longSpawnPoint, Data.Instance.PrefabsData.longPrefab);
            CreatePrefabOnSpawnPoint(_bigSpawnPoint, Data.Instance.PrefabsData.bigPrefab);
            CreateRandomPrefabsOnSpawnPoint(_botSpawnPoint, Data.Instance.PrefabsData.botPrefab, Data.Instance.PrefabsData.botBigPrefab, 8);
            CreateRandomPrefabOnSpawnPoint(_botSpawnPoint, Data.Instance.PrefabsData.magicPrefab, 10);
        }

        if (LevelController.CountScore >= _score.levelSevenScore)
        {
            CreatePrefabOnSpawnPoint(_smallSpawnPoint, Data.Instance.PrefabsData.smallPrefab);
            CreatePrefabOnSpawnPoint(_midleSpawnPoint, Data.Instance.PrefabsData.midlePrefab);
            CreatePrefabOnSpawnPoint(_longSpawnPoint, Data.Instance.PrefabsData.longPrefab);
            CreatePrefabOnSpawnPoint(_bigSpawnPoint, Data.Instance.PrefabsData.bigPrefab);
            CreateRandomPrefabsOnSpawnPoint(_botSpawnPoint, Data.Instance.PrefabsData.botPrefab, Data.Instance.PrefabsData.botBigPrefab, 5);
            CreateRandomPrefabOnSpawnPoint(_botSpawnPoint, Data.Instance.PrefabsData.magicPrefab, 5);
        }
    }

    private void CreatePrefabOnSpawnPoint(Transform[] spawnPoint, string[] prefabs)
    {
        if (spawnPoint.Length > 0)
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                prefab = PoolManager.GetObject(prefabs[Random.Range(0, prefabs.Length)],
                    spawnPoint[i].transform.position, Quaternion.identity);
                prefab.transform.SetParent(gameObject.transform);
            }
        }
    }

    private void CreateRandomPrefabOnSpawnPoint(Transform[] spawnPoint, string[] prefabs, int rnd)
    {
        if (spawnPoint.Length > 0)
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                if (Random.Range(0, rnd) == 1)
                {
                    prefab = PoolManager.GetObject(prefabs[Random.Range(0, prefabs.Length)],
                        spawnPoint[i].transform.position, Quaternion.identity);
                    prefab.transform.SetParent(gameObject.transform);
                }
            }
        }
    }

    private void CreateRandomPrefabsOnSpawnPoint(Transform[] spawnPoint, string[] prefabsOne, string[] prefabsTwo, int rnd)
    {
        if (spawnPoint.Length > 0)
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                prefab = PoolManager.GetObject(ReturnRandomPrefabs(prefabsOne, prefabsTwo, rnd),
                    spawnPoint[i].transform.position, Quaternion.identity);
                prefab.transform.SetParent(gameObject.transform);
            }
        }
    }

    private string ReturnRandomPrefabs(string[] prefabsOne, string[] prefabsTwo, int rnd)
    {
        return Random.Range(0, rnd) == 1 ? prefabsTwo[Random.Range(0, prefabsTwo.Length)] : prefabsOne[Random.Range(0, prefabsOne.Length)];
    }
}