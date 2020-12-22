using Scripts;
using UnityEngine;


[RequireComponent(typeof(PoolObject), typeof(BoxCollider))]
public abstract class BombBase : BaseModel
{
    [SerializeField] protected float radius = 0.0f;
    protected LayerMask targetLayer;
    protected Collider[] hitColliders = new Collider[10];
    protected int countColliders;

    protected override void Awake()
    {
        base.Awake();
        targetLayer = LayerManager.TargetLayer;
    }

    public abstract void ExplodedBomb();

    protected void DestroyBomb()
    {
        gameObject.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }

    public void DestroyBombWhenPlatformDestroyed()
    {
        gameObject.GetComponent<PoolObject>().ReturnToPool();
        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyObjParticle,
            gameObject.transform.position, Quaternion.identity);

        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }
}