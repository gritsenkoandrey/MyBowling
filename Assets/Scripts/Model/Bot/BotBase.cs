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
    private static readonly int _attackOn = Animator.StringToHash("AttackOn");
    private static readonly int _attackOff = Animator.StringToHash("AttackOff");

    protected override void Awake()
    {
        base.Awake();
        _uiShowText = FindObjectOfType<UiShowApplyDamage>();
        _animator = GetComponentInChildren<Animator>();

        _timeRemainingDestroyGun = new TimeRemaining(DestroyGun, _timeToDestroyGun);
        _timeRemainingThrowStone = new TimeRemaining(ThrowStone, _timeToThrowStone);
    }

    public abstract void DestroyBotWithBall();
    public abstract void DestroyBotWithBomb();

    public void DestroyBotWhenPlatformDestroyed()
    {
        this.gameObject.GetComponent<PoolObject>().ReturnToPool();
        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyObjParticle,
            gameObject.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }

    protected void DestroyBot()
    {
        Services.Instance.CameraServices.CreateShake(ShakeType.Standart);
        _uiShowText.ApplyDamage(gameObject.transform.position, _points * BallBase.Instance.currentHitCounter++);

        gameObject.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingReturnToPoolCollision.AddTimeRemaining();
    }

    public void AttackGun()
    {
        _animator.SetTrigger(_attackOn);
        _timeRemainingThrowStone.AddTimeRemaining();
        _timeRemainingDestroyGun.AddTimeRemaining();
    }

    private void DestroyGun()
    {
        gun.DestroyGun();
        _timeRemainingDestroyGun.RemoveTimeRemaining();
        DestroyStone();
    }

    private void ThrowStone()
    {
        _animator.SetTrigger(_attackOff);
        obj = PoolManager.GetObject(Data.Instance.PrefabsData.stone,
            gameObject.transform.position, Quaternion.identity);
        obj.transform.DOMove(Data.Instance.Ball.spawnBallPosition, _timeToThrowStone);
        _timeRemainingThrowStone.RemoveTimeRemaining();
    }

    private void DestroyStone()
    {
        obj.transform.DOKill();
        obj.GetComponent<PoolObject>().ReturnToPool();
    }
}