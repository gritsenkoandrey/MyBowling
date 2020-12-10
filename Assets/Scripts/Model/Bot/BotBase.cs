using Scripts;
using UnityEngine;


[RequireComponent(typeof(PoolObject), (typeof(CapsuleCollider)))]
public abstract class BotBase : BaseModel
{
    [SerializeField] private int _points = 0;
    private UiShowApplyDamage _uiShowText;

    protected override void Awake()
    {
        base.Awake();
        _uiShowText = FindObjectOfType<UiShowApplyDamage>();
    }

    protected void ReturnToPool()
    {
        DestroyBot();
        timeRemainingReturnToPoolCollision.AddTimeRemaining();
    }

    private void DestroyBot()
    {
        Services.Instance.CameraServices.CreateShake(ShakeType.Standart);
        _uiShowText.ApplyDamage(gameObject.transform.position, _points * BallController.CurrentHitCounter++);
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }

    public abstract void DestroyBotWithBall();

    public void DestroyBotWhenPlatformDestroyed()
    {
        this.gameObject.GetComponent<PoolObject>().ReturnToPool();
        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyObjParticle,
            gameObject.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }
}