using Scripts;
using UnityEngine;


[RequireComponent(typeof(PoolObject), (typeof(BoxCollider)))]
public abstract class AimBase : BaseModel
{
    [SerializeField] private int _points = 0;

    private UiShowApplyDamage _uiShowText;

    protected override void Awake()
    {
        base.Awake();

        _uiShowText = FindObjectOfType<UiShowApplyDamage>();
    }

    protected void DestroyAim()
    {
        _uiShowText.ApplyDamage(gameObject.transform.position, _points * BallBase.Instance.HitCounter++);
        gameObject.GetComponent<PoolObject>().ReturnToPool();

        timeRemainingReturnToPoolParticle.AddTimeRemaining();
        ResetTransformObject();
    }

    public abstract void DestroyAimParticle();

    public abstract void DestroyAimWithBomb();

    public void DestroyAimWhenPlatformDestroyed()
    {
        gameObject.GetComponent<PoolObject>().ReturnToPool();
        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyObjParticle,
            gameObject.transform.position, Quaternion.identity);

        timeRemainingReturnToPoolParticle.AddTimeRemaining();
        ResetTransformObject();
    }
}