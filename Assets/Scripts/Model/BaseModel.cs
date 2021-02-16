using Scripts;
using UnityEngine;


public abstract class BaseModel : MonoBehaviour
{
    protected GameObject collisionObject;
    protected GameObject particleObject;
    protected GameObject prefab;

    protected BotBase bot;
    protected BallBase ball;
    protected AimBase aim;
    protected BuildingBase building;
    protected BombBase bomb;
    protected Gun gun;

    protected TimeRemaining timeRemainingReturnToPoolCollision;
    protected TimeRemaining timeRemainingReturnToPoolParticle;

    private readonly float _timeReturnToPoolCollision = 1.5f;
    private readonly float _timeReturnToPoolParticle = 3.0f;

    protected virtual void Awake()
    {
        timeRemainingReturnToPoolCollision = new TimeRemaining(ReturnToPoolCollision, _timeReturnToPoolCollision);
        timeRemainingReturnToPoolParticle = new TimeRemaining(ReturnToPoolParticle, _timeReturnToPoolParticle);

        gun = FindObjectOfType<Gun>();
    }

    protected void ResetTransformObject()
    {
        gameObject.transform.SetParent(PoolManager.objectsParent.transform);
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.rotation = Quaternion.identity;
    }

    private void ReturnToPoolCollision()
    {
        collisionObject.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingReturnToPoolCollision.RemoveTimeRemaining();
    }

    private void ReturnToPoolParticle()
    {
        particleObject.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingReturnToPoolParticle.RemoveTimeRemaining();
    }
}