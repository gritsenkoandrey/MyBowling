using Scripts;
using System;


public abstract class AimBase : BaseModel
{
    protected readonly string _destroyTreeParticle = "DestroyObjParticle_2";
    protected readonly string _destroyBoxParticle = "DestroyObjParticle_1";

    public event Action<AimBase> OnDieChange;

    protected void ReturnToPool()
    {
        OnDieChange?.Invoke(this);
        this.gameObject.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }

    public abstract void DestroyAimParticle();
}