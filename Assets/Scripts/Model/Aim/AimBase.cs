using Scripts;
using UnityEngine;


[RequireComponent(typeof(PoolObject), (typeof(BoxCollider)))]
public abstract class AimBase : BaseModel
{
    //public event Action<AimBase> OnDieChange;
    [SerializeField] private int _points = 0;

    private UiShowApplyDamage _uiShowText;

    protected override void Awake()
    {
        base.Awake();

        _uiShowText = FindObjectOfType<UiShowApplyDamage>();
    }

    protected void ReturnToPool()
    {
        //OnDieChange?.Invoke(this);
        _uiShowText.ApplyDamage(gameObject.transform.position, _points * BallController.CurrentHitCounter++);
        this.gameObject.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }

    public abstract void DestroyAimParticle();

    public void DestroyAimWhenPlatformDestroyed()
    {
        //OnDieChange?.Invoke(this);
        this.gameObject.GetComponent<PoolObject>().ReturnToPool();
        particleObject = PoolManager.
            GetObject(Data.Instance.PrefabsData.destroyObjParticle, gameObject.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }
}