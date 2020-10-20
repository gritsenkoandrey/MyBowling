using Scripts;
using UnityEngine;


public abstract class AimBase : BaseModel
{
    [Range(0.0f, 5.0f), SerializeField] private float _returnParticleToPool = 0.0f;

    protected readonly string _destroyTreeParticle = "DestroyObjParticle_2";
    protected readonly string _destroyBoxParticle = "DestroyObjParticle_1";

    protected GameObject particleObj;
    protected TimeRemaining timeRemaining;

    protected override void Awake()
    {
        base.Awake();

        timeRemaining = new TimeRemaining(ReturnToPollParticle, _returnParticleToPool);
    }

    private void ReturnToPollParticle()
    {
        particleObj.GetComponent<PoolObject>().ReturnToPool();
        timeRemaining.RemoveTimeRemaining();
    }

    protected void ReturnToPool()
    {
        gameObject.GetComponent<PoolObject>().ReturnToPool();
        timeRemaining.AddTimeRemaining();
    }

    public abstract void DestroyAimParticle();
}