using Scripts;
using UnityEngine;


public abstract class BotBase : BaseModel
{
    [Range(0.0f, 5.0f), SerializeField] private float _returnParticleToPool = 0.0f;

    protected float posYSpawnCorrection = 2.0f;

    protected readonly string destroyBotParticleGreen = "DestroyBotGreenParticle_1";
    protected readonly string destroyBotCollisionGreen = "GreenRingImpact";
    protected readonly string destroyBotParticleCop = "DestroyBotCopParticle_2";
    protected readonly string destroyBotParticleCowboy = "DestroyBotCowboyParticle_3";
    protected readonly string destroyBotCollisionCop = "BlueRingImpact";
    protected readonly string destroyBotCollisionCowboy = "YellowRingImpact";

    protected TimeRemaining timeRemainingDestroyParticle;
    protected TimeRemaining timeRemainingCollision;

    protected GameObject particleObj;
    protected GameObject collisionObj;

    private CameraShake _cameraShake;

    protected override void Awake()
    {
        base.Awake();

        _cameraShake = FindObjectOfType<CameraShake>();

        timeRemainingDestroyParticle = new TimeRemaining(ReturnToPoolParticle, _returnParticleToPool);
        timeRemainingCollision = new TimeRemaining(ReturnToPoolCollision, _returnParticleToPool);
    }

    private void ReturnToPoolParticle()
    {
        particleObj.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingDestroyParticle.RemoveTimeRemaining();
    }

    private void ReturnToPoolCollision()
    {
        collisionObj.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingCollision.RemoveTimeRemaining();
    }

    protected void ReturnToPool()
    {
        timeRemainingDestroyParticle.AddTimeRemaining();
        timeRemainingCollision.AddTimeRemaining();
        DestroyBot();
    }

    private void DestroyBot()
    {
        _cameraShake.CreateShake();
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }

    public abstract void DestroyBotWithBall();
    public abstract void DestroyBotWithParticle();
}