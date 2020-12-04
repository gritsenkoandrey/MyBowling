using Scripts;
using UnityEngine;


[RequireComponent(typeof(PoolObject), (typeof(CapsuleCollider)))]
public abstract class BotBase : BaseModel
{
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
        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyObjParticle,
            gameObject.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }
}