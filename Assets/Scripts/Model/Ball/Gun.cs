﻿using Scripts;
using UnityEngine;


public sealed class Gun : BaseModel
{
    private bool _isGunAlive;

    private static readonly int _fireOn = Animator.StringToHash("FireOn");
    private static readonly int _fireOff = Animator.StringToHash("FireOff");

    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();

        _isGunAlive = true;
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

    public void FireParticleON()
    {
        obj = PoolManager.GetObject(Data.Instance.PrefabsData.canonShotParticle,
            Data.Instance.Ball.spawnBallPosition, Quaternion.identity);
    }

    public void FireParticleOff()
    {
        obj.GetComponent<PoolObject>().ReturnToPool();
    }

    public void DestroyGun()
    {
        if (_isGunAlive)
        {
            gameObject.GetComponent<PoolObject>().ReturnToPool();
            obj = PoolManager.GetObject(Data.Instance.PrefabsData.bombExplosion,
                Data.Instance.Ball.spawnBallPosition, Quaternion.identity);

            _isGunAlive = false;
        }
    }
}