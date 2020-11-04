using System.Collections.Generic;


public static class AimManager
{
    private static List<AimBase> _aimList;

    static AimManager()
    {
        _aimList = new List<AimBase>();
    }

    public static void AddAimToList(AimBase aim)
    {
        if (!_aimList.Contains(aim))
        {
            _aimList.Add(aim);
            aim.OnDieChange += RemoveAimToList;
        }
    }

    public static void RemoveAimToList(AimBase aim)
    {
        if (!_aimList.Contains(aim))
        {
            return;
        }
        aim.OnDieChange -= RemoveAimToList;
        _aimList.Remove(aim);
    }

    //public static void AimSpawner(AimSpawner aimSpawner)
    //{
    //    if (_aimList.Count == 0)
    //    {
    //        //aimSpawner.SpawnAim();
    //    }
    //}

    public static bool AimDestroyed()
    {
        if (_aimList.Count == 0)
        {
            return true;
        }
        else
            return false;
    }
}