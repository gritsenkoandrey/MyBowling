using Scripts;


public abstract class AimBase : BaseModel
{
    protected readonly string _destroyTreeParticle = "DestroyObjParticle_2";
    protected readonly string _destroyBoxParticle = "DestroyObjParticle_1";

    //todo сделать два таймера для particle

    public abstract void DestroyAimParticle();

    protected void ReturnToPool()
    {
        timeRemainingReturnToPoolTwo.AddTimeRemaining();
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }
}