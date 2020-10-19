using Scripts;
using UnityEngine;


public abstract class BotBase : BaseModel
{
    [Range(0.0f, 5.0f), SerializeField] private float _destroyBotByTime = 0.0f;

    protected readonly string _destroyBotParticleCop = "DestroyBotCopParticle_2";
    protected readonly string _destroyBotParticleCowboy = "DestroyBotCowboyParticle_3";
    protected readonly string _destroyBotCollisionCop = "BlueRingImpact";
    protected readonly string _destroyBotCollisionCowboy = "GreenRingImpact";

    protected TimeRemaining timeRemainingDestroyBot;

    private CameraShake _cameraShake;

    private void Start()
    {
        _cameraShake = FindObjectOfType<CameraShake>();

        timeRemainingDestroyBot = new TimeRemaining(DestroyBot, _destroyBotByTime);
    }

    public abstract void DestroyBotWithBall();
    public abstract void DestroyBotWithParticle();

    private void DestroyBot()
    {
        _cameraShake.CreateShake();
        gameObject.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingDestroyBot.RemoveTimeRemaining();
    }
}