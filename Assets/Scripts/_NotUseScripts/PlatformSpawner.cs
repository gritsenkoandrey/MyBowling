using Scripts;
using UnityEngine;


public sealed class PlatformSpawner : BaseModel
{
    // Реализация уничтожения всех платформ при убийстве всех ботов.
    //данный класс не используется

    //private readonly string[] _platforms = { "Big_Platform", "Medium_Platform", "Small_Platform"};
    //private readonly float[] _spawnPlatformPositionZ = { 20.0f, 30.0f, 40.0f, 50.0f, 60.0f, 70.0f };

    //private readonly byte _maxPlatformCount = 6;
    //private readonly byte _minPlatformCount = 0;
    //public static  byte CurrentPlatformCount;

    //public static bool IsReadySpawn = false;

    //private TimeRemaining _timeRemainingReturnToPoolPlatform;
    //private TimeRemaining _timeRemainingReturnToPollTarget;

    //private readonly float _timeToReturnTopoolPlatform = 3.0f;
    //private readonly float _timeToReturnToPoolTarget = 0.75f;

    //protected override void Awake()
    //{
    //    base.Awake();

    //    CurrentPlatformCount = _minPlatformCount;
    //    IsReadySpawn = true;

    //    _timeRemainingReturnToPoolPlatform = new TimeRemaining(ReturnToPoolPlatform, _timeToReturnTopoolPlatform);
    //    _timeRemainingReturnToPollTarget = new TimeRemaining(ReturnToPoolTarget, _timeToReturnToPoolTarget);
    //}

    //public void Spawn()
    //{
    //    GeneratePlatform();
    //    PreparingForRespawn();
    //}

    //private void GeneratePlatform()
    //{
    //    if (CurrentPlatformCount < _maxPlatformCount && IsReadySpawn == true)
    //    {
    //        for (int i = CurrentPlatformCount; i < _maxPlatformCount; i++)
    //        {
    //            obj = PoolManager.GetObject(_platforms[Random.Range(0, _platforms.Length)],
    //                new Vector3(0.0f, 0.0f, _spawnPlatformPositionZ[i]), Quaternion.identity);
    //            obj.GetComponent<Platform>().SpawnTargetOnPlatform();
    //            obj.GetComponent<Platform>().MoveAddTimer();
    //            CurrentPlatformCount++;
    //        }

    //        IsReadySpawn = false;
    //    }
    //}

    //private void PreparingForRespawn()
    //{
    //    if (CurrentPlatformCount == _maxPlatformCount && BotManager.BotDestroyed() && IsReadySpawn == false)
    //    {
    //        _timeRemainingReturnToPollTarget.AddTimeRemaining();
    //        _timeRemainingReturnToPoolPlatform.AddTimeRemaining();
    //    }
    //}

    //private void ReturnToPoolPlatform()
    //{
    //    var platform = FindObjectsOfType<Platform>();
    //    for (int i = 0; i < platform.Length; i++)
    //    {
    //        platform[i].RemoveTimer();
    //        platform[i].GetComponent<PoolObject>().ReturnToPool();
    //        CurrentPlatformCount--;
    //    }

    //    _timeRemainingReturnToPoolPlatform.RemoveTimeRemaining();
    //}

    //private void ReturnToPoolTarget()
    //{
    //    if (!IsReadySpawn)
    //    {
    //        var aim = FindObjectsOfType<AimBase>();
    //        for (int i = 0; i < aim.Length; i++)
    //        {
    //            aim[i].DestroyAimWhenLevelClean();
    //        }

    //        var building = FindObjectsOfType<BuildingBase>();
    //        for (int i = 0; i < building.Length; i++)
    //        {
    //            building[i].DestroyBuildingWhenLevelClean();
    //        }

    //        IsReadySpawn = true;
    //        _timeRemainingReturnToPollTarget.RemoveTimeRemaining();
    //    }
    //}
}