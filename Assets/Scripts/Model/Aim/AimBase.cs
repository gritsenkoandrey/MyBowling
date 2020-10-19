public abstract class AimBase : BaseModel
{
    protected readonly string _destroyTreeParticle = "DestroyObjParticle_2";
    protected readonly string _destroyBoxParticle = "DestroyObjParticle_1";

    public abstract void DestroyAimParticle();
}