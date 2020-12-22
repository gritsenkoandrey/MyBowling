using Scripts;
using UnityEngine;


[RequireComponent(typeof(PoolObject), (typeof(BoxCollider)))]
public abstract class BuildingBase : BaseModel
{
    [SerializeField] private int _points = 0;
    [SerializeField] private int _maxHealth = 0;
    protected readonly int minHealth = 0;
    private int _currentHealth;

    private UiShowApplyDamage _uiShowText;

    public int Health
    {
        get { return _currentHealth; }
        protected set { _currentHealth = value; }
    }

    protected override void Awake()
    {
        base.Awake();
        _uiShowText = FindObjectOfType<UiShowApplyDamage>();
    }

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    public abstract void BuildingDestroyParticle();
    public abstract void BuildingDestroyWithBomb();

    protected void DestroyBuilding()
    {
        _uiShowText.ApplyDamage(gameObject.transform.position, _points * BallBase.Instance.currentHitCounter++);
        gameObject.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }

    public void DestroyBuildingWhenPlatformDestroyed()
    {
        gameObject.GetComponent<PoolObject>().ReturnToPool();

        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyObjParticle,
            gameObject.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }
}