using Scripts;
using UnityEngine;


public abstract class BotBase : BaseModel
{
    [Range(0.0f, 5.0f), SerializeField] private float _destroyBotByTime = 0.0f;
    protected float hightCorrection = 2.0f;

    protected readonly string destroyBotParticleGreen = "DestroyBotGreenParticle_1";
    protected readonly string destroyBotCollisionGreen = "GreenRingImpact";
    protected readonly string destroyBotParticleCop = "DestroyBotCopParticle_2";
    protected readonly string destroyBotParticleCowboy = "DestroyBotCowboyParticle_3";
    protected readonly string destroyBotCollisionCop = "BlueRingImpact";
    protected readonly string destroyBotCollisionCowboy = "YellowRingImpact";

    //todo сделать два таймера для particle и collision
    protected TimeRemaining timeRemainingDestroyBot;

    private CameraShake _cameraShake;

    private void Start()
    {
        _cameraShake = FindObjectOfType<CameraShake>();

        timeRemainingDestroyBot = new TimeRemaining(DestroyBot, _destroyBotByTime);
    }

    public abstract void DestroyBotWithBall();
    public abstract void DestroyBotWithParticle();

    protected void ReturnToPool()
    {
        timeRemainingReturnToPoolOne.AddTimeRemaining();
        timeRemainingReturnToPoolTwo.AddTimeRemaining();
        timeRemainingDestroyBot.AddTimeRemaining();
    }

    private void DestroyBot()
    {
        _cameraShake.CreateShake();
        gameObject.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingDestroyBot.RemoveTimeRemaining();
    }
}