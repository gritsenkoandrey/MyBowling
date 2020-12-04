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

        gameObject.transform.DOKill();
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