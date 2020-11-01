using Scripts;
using System;
using UnityEngine;


public abstract class AimBase : BaseModel
{
    public event Action<AimBase> OnDieChange;

    [SerializeField] private int _points = 0;

    private UiShowText _uiShowText;

    protected override void Awake()
    {
        base.Awake();
        _uiShowText = FindObjectOfType<UiShowText>();
    }

    protected void ReturnToPool()
    {
        OnDieChange?.Invoke(this);

        _uiShowText.ApplyDamage(gameObject.transform.position, _points);

        this.gameObject.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }

    public abstract void DestroyAimParticle();
}