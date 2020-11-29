using UnityEngine;


public sealed class GameBoundary : BaseModel
{
    private Platform _platform;

    private void OnTriggerEnter(Collider other)
    {
        _platform = other.GetComponent<Platform>();
        if (_platform)
        {
            _platform.DestroyPlatform();
        }
    }
}