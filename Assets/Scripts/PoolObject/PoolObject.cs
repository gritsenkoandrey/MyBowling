using UnityEngine;


[AddComponentMenu("Pool/PoolObject")]
public sealed class PoolObject : MonoBehaviour
{
    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}