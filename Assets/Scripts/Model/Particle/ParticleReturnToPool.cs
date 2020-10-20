using Scripts;
using UnityEngine;


public sealed class ParticleReturnToPool : BaseModel
{
    private TimeRemaining _timeRemaining;
    private float _timeToPool = 5.0f;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _timeRemaining = new TimeRemaining(ReturnToPool, _timeToPool, true);
        _timeRemaining.AddTimeRemaining();
    }

    private void ReturnToPool()
    {
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }
}