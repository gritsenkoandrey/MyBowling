using Scripts;


public abstract class AimBase : BaseModel
{
    protected readonly string _destroyTreeParticle = "DestroyObjParticle_2";
    protected readonly string _destroyBoxParticle = "DestroyObjParticle_1";

    protected void ReturnToPool()
    {
        this.gameObject.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }

    public abstract void DestroyAimParticle();
}