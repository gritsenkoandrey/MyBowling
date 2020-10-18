using UnityEngine;


[AddComponentMenu("Pool/PoolSetup")]
public sealed class PoolSetup : MonoBehaviour
{
    [SerializeField] private PoolManager.PoolPart[] _pools;

    private void OnValidate()
    {
        for (int i = 0; i < _pools.Length; i++)
        {
            _pools[i].Name = _pools[i].Prefab.name;
        }
    }

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        PoolManager.Initialize(_pools);
    }
}