using Scripts;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(PoolObject), (typeof(CapsuleCollider)))]
public abstract class BotBase : BaseModel
{
    [SerializeField] private int _points = 0;

    private UiShowApplyDamage _uiShowText;

    private TimeRemaining _timeRemainingDestroyGun;
    private TimeRemaining _timeRemainingThrowStone;
    private readonly float _timeToDestroyGun = 2.5f;
    private readonly float _timeToThrowStone = 1.5f;

    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _uiShowText = FindObjectOfType<UiShowApplyDamage>();
        _animator = GetComponent<Animator>();

        _timeRemainingDestroyGun = new TimeRemaining(DestroyGun, _timeToDestroyGun);
        _timeRemainingThrowStone = new TimeRemaining(ThrowStone, _timeToThrowStone);
    }

    public abstract void DestroyBotWithBall();
    public abstract void DestroyBotWithBomb();

    //for debug
    public void DestroyBotWhenPlatformDestroyed()
    {
        gameObject.GetComponent<PoolObject>().ReturnToPool();
        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyObjParticle,
            gameObject.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolParticle.AddTimeRemaining();

        ResetTransformObject();
    }

    protected void DestroyBot()
    {
        Services.Instance.CameraServices.CreateShake(ShakeType.Standart);
        _uiShowText.ApplyDamage(gameObject.transform.position, _points * BallBase.Instance.HitCounter++);

        gameObject.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingReturnToPoolCollision.AddTimeRemaining();

        ResetTransformObject();
    }

    public void AttackGun()
    {
        _animator.SetTrigger(NameManager.ATTACK_ON_BOT_ANIMATION);
        _timeRemainingThrowStone.AddTimeRemaining();
        _timeRemainingDestroyGun.AddTimeRemaining();
    }

    private void DestroyGun()
    {
        gun.DestroyGun();
        _timeRemainingDestroyGun.RemoveTimeRemaining();
        DestroyStone();
    }

    private void DestroyStone()
    {
        prefab.transform.DOKill();
        prefab.GetComponent<PoolObject>().ReturnToPool();
    }

    private void ThrowStone()
    {
        _animator.SetTrigger(NameManager.ATTACK_OFF_BOT_ANIMATION);
        prefab = PoolManager.GetObject(Data.Instance.PrefabsData.stone,
            gameObject.transform.position, Quaternion.identity);
        prefab.transform.DOMove(Data.Instance.Ball.spawnBallPosition, _timeToThrowStone);
        _timeRemainingThrowStone.RemoveTimeRemaining();
    }
}