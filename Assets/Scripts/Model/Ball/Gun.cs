using Scripts;
using UnityEngine;


public sealed class Gun : BaseModel
{
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();

        _animator = GetComponent<Animator>();
    }

    public void FireOn()
    {
        _animator.SetTrigger(NameManager.FIRE_ON_GUN_ANIMATION);
    }

    public void FireOff()
    {
        _animator.SetTrigger(NameManager.FIRE_OFF_GUN_ANIMATION);
    }

    public void FireParticleON()
    {
        prefab = PoolManager.GetObject(Data.Instance.PrefabsData.canonShotParticle,
            Data.Instance.Ball.spawnBallPosition, Quaternion.identity);
    }

    public void FireParticleOff()
    {
        prefab.GetComponent<PoolObject>().ReturnToPool();
    }

    public void DestroyGun()
    {
        Services.Instance.AudioService.PlaySound(AudioName.EXPLOSION_BALL);
        gameObject.GetComponent<PoolObject>().ReturnToPool();
        prefab = PoolManager.GetObject(Data.Instance.PrefabsData.bombExplosion,
            Data.Instance.Ball.spawnBallPosition, Quaternion.identity);
    }
}