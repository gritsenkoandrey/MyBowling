using Scripts;
//using System;
using UnityEngine;


[RequireComponent(typeof(PoolObject))]
public abstract class BotBase : BaseModel
{
    private readonly string _aimParticleDestroyWhenLevelClean = "FX_Explosion_01";

    [SerializeField] private int _points = 0;

    private CameraShake _cameraShake;
    private UiShowApplyDamage _uiShowText;

    //public event Action<BotBase> OnDieChange;

    protected override void Awake()
    {
        base.Awake();

        _cameraShake = FindObjectOfType<CameraShake>();
        _uiShowText = FindObjectOfType<UiShowApplyDamage>();
    }

    protected void ReturnToPool()
    {
        DestroyBot();
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
        timeRemainingReturnToPoolCollision.AddTimeRemaining();
    }

    private void DestroyBot()
    {
        //OnDieChange?.Invoke(this);
        _cameraShake.CreateShake();
        _uiShowText.ApplyDamage(gameObject.transform.position, _points * BallController.CurrentHitCounter++);
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }

    public abstract void DestroyBotWithBall();

    public void DestroyBotWhenPlatformDestroyed()
    {
        //OnDieChange?.Invoke(this);
        this.gameObject.GetComponent<PoolObject>().ReturnToPool();
        particleObject = PoolManager.
            GetObject(_aimParticleDestroyWhenLevelClean, gameObject.transform.position, Quaternion.identity);

        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }
}