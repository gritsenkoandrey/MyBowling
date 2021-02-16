using System;
using UnityEngine;


public static class PoolManager
{
    private static PoolPart[] _pools;
    public static GameObject objectsParent;

    [Serializable]
    public struct PoolPart
    {
        public string Name;
        public PoolObject Prefab;
        public int Count;
        public ObjectPooling Pool;
    }

    public static void Initialize(PoolPart[] newPool)
    {
        _pools = newPool;
        objectsParent = new GameObject();
        objectsParent.name = "Pool";

        for (int i = 0; i < _pools.Length; i++)
        {
            if (_pools[i].Prefab != null)
            {
                _pools[i].Pool = new ObjectPooling();
                _pools[i].Pool.Initialize(_pools[i].Count, _pools[i].Prefab, objectsParent.transform);
            }
        }
    }

    public static GameObject GetObject(string name, Vector3 position, Quaternion rotation)
    {
        GameObject result = null;
        if (_pools != null)
        {
            for (int i = 0; i < _pools.Length; i++)
            {
                if (string.Compare(_pools[i].Name, name) == 0)
                {
                    result = _pools[i].Pool.GetObject().gameObject;
                    result.transform.position = position;
                    result.transform.rotation = rotation;
                    result.SetActive(true);
                    return result;
                }
            }
        }
        return result;
    }
}