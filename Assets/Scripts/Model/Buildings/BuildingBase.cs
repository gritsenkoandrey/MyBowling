using Scripts;
using UnityEngine;


[RequireComponent(typeof(PoolObject), (typeof(BoxCollider)))]
public sealed class BuildingBase : BaseModel
{
    [SerializeField] private int _health = 0;
    [SerializeField] private int _points = 0;

    private UiShowApplyDamage _uiShowText;

    protected override void Awake()
    {
        base.Awake();

        _uiShowText = FindObjectOfType<UiShowApplyDamage>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ball = collision.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            _health--;
            BuildingCollision();

            if (_health <= 0)
            {
                BuildingDestroy();
            }
        }
    }

    private void BuildingCollision()
    {
        collisionObject = PoolManager.GetObject(Data.Instance.PrefabsData.impactCollision, 
            ball.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolCollision.AddTimeRemaining();
    }

    private void BuildingDestroy()
    {
        _uiShowText.ApplyDamage(gameObject.transform.position, _points * BallController.CurrentHitCounter++);

        gameObject.GetComponent<PoolObject>().ReturnToPool();

        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyBuildingParticle,
            ball.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }

    public void DestroyBuildingWhenPlatformDestroyed()
    {
        gameObject.GetComponent<PoolObject>().ReturnToPool();
        particleObject = PoolManager.
            GetObject(Data.Instance.PrefabsData.destroyObjParticle,
            gameObject.transform.position, Quaternion.identity);

        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }
}