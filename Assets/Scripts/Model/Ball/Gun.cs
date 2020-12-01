using Scripts;
using UnityEngine;


public sealed class Gun : BaseModel
{
    private Animator _animator;
    private Vector3 _particlePos = new Vector3(0.0f, 2.5f, -19.0f);

    private static readonly int _fireOn = Animator.StringToHash("FireOn");
    private static readonly int _fireOff = Animator.StringToHash("FireOff");

    protected override void Awake()
    {
        base.Awake();

        _animator = GetComponent<Animator>();
    }

    public void FireOn()
    {
        _animator.SetTrigger(_fireOn);
    }

    public void FireOff()
    {
        _animator.SetTrigger(_fireOff);
    }

    public void FireParticle()
    {
        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.canonShotParticle,
            _particlePos, Quaternion.identity);
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }
}