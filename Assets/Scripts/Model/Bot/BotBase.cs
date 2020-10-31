using Scripts;
using System;


public abstract class BotBase : BaseModel
{
    protected float spawnCorrection = 2.0f;

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