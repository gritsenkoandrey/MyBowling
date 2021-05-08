using Scripts;
using UnityEngine;


[RequireComponent(typeof(PoolObject), (typeof(BoxCollider)))]
public abstract class BuildingBase : BaseModel
{
    [SerializeField] private int _points = 0;
    [SerializeField] private int _maxHealth = 0;
    protected readonly int minHealth = 0;
    private int _currentHealth;

    public int Health
    {
        get { return _currentHealth; }
        protected set { _currentHealth = value; }
    }

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    public abstract void BuildingDestroyParticle();
    public abstract void BuildingDestroyWithBomb();

    protected void DestroyBuilding()
    {
        //Services.Instance.EventService.ApplyDamage(gameObject.transform.position, _points * BallBase.Instance.HitCounter++);
        gameObject.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
        ResetTransformObject();
    }

    public void DestroyBuildingWhenPlatformDestroyed()
    {
        gameObject.GetComponent<PoolObject>().ReturnToPool();

        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyObjParticle,
            gameObject.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
        ResetTransformObject();
    }
}