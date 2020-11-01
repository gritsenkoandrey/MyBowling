using Scripts;
using System;
using UnityEngine;


public abstract class BotBase : BaseModel
{
    protected float spawnCorrection = 2.0f;
    [SerializeField] private int _points = 0;

    private CameraShake _cameraShake;
    private UiShowText _uiShowText;

    public event Action<BotBase> OnDieChange;

    protected override void Awake()
    {
        base.Awake();

        _cameraShake = FindObjectOfType<CameraShake>();
        _uiShowText = FindObjectOfType<UiShowText>();
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
        _uiShowText.ApplyDamage(gameObject.transform.position, _points);

        OnDieChange?.Invoke(this);
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }

    public abstract void DestroyBotWithBall();
    public abstract void DestroyBotWithParticle();
}