using UnityEngine;


[CreateAssetMenu(fileName = "PlatformData", menuName = "Data/PlatformSettings/PlatformData")]
public class PlatformData : ScriptableObject
{
    [SerializeField] private SerializePlatformData[] _platform;

    public PlatformInfo GetPlatformInfo(PlatformType type)
    {
        PlatformInfo result = default;

        foreach (var platformData in _platform)
        {
            if (platformData.PlatformType == type)
            {
                result = platformData.PlatformInfo;
            }
        }
        return result;
    }
}