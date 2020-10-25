using System.Collections.Generic;


public static class AimManager
{
    private static List<AimBase> _aimList;

    static AimManager()
    {
        _aimList = new List<AimBase>();
    }

    public static void AddBotToList(AimBase aim)
    {
        if (!_aimList.Contains(aim))
        {
            _aimList.Add(aim);
            aim.OnDieChange += RemoveBotToList;
        }
    }

    public static void RemoveBotToList(AimBase aim)
    {
        if (!_aimList.Contains(aim))
        {
            return;
        }
        aim.OnDieChange -= RemoveBotToList;
        _aimList.Remove(aim);
    }

    public static void AimSpawner(AimSpawner aimSpawner)
    {
        if (_aimList.Count == 0)
        {
            aimSpawner.SpawnAim();
        }
    }
}