using Scripts;
using System;


public abstract class BotBase : BaseModel
{
    protected float spawnCorrection = 2.0f;

    protected readonly string destroyBotParticleGreen = "DestroyBotGreenParticle_1";
    protected readonly string destroyBotParticleCop = "DestroyBotCopParticle_2";
    protected readonly string destroyBotParticleCowboy = "DestroyBotCowboyParticle_3";
    protected readonly string destroyBotCollisionGreen = "GreenRingImpact";
    protected readonly string destroyBotCollisionCop = "BlueRingImpact";
    protected readonly string destroyBotCollisionCowboy = "YellowRingImpact";

    private CameraShake _cameraShake;

    public event Action<BotBase> OnDieChange;

    protected override void Awake()
    {
        base.Awake();

        _cameraShake = FindObjectOfType<CameraShake>();
    }

    protected void ReturnToPool()
    {
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
        timeRemainingReturnToPoolCollision.AddTimeRemaining();
        DestroyBot();
    }

    private void DestroyBot()
    {
        _cameraShake.CreateShake();
        OnDieChange?.Invoke(this);
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }

    public abstract void DestroyBotWithBall();
    public abstract void DestroyBotWithParticle();
}