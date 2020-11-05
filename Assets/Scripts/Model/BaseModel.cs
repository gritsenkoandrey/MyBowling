using Scripts;
using UnityEngine;


public abstract class BaseModel : MonoBehaviour
{
    protected GameObject collisionObject;
    protected GameObject particleObject;
    protected GameObject obj;

    protected Rigidbody rigidbodyBase;
    protected Transform transformBase;

    protected BotBase bot;
    protected BallBase ball;
    protected AimBase aim;
    protected BuildingBase building;

    protected TimeRemaining timeRemainingReturnToPoolCollision;
    protected TimeRemaining timeRemainingReturnToPoolParticle;

    private readonly float _timeReturnToPoolCollision = 1.5f;
    private readonly float _timeReturnToPoolParticle = 3.0f;

    protected virtual void Awake()
    {
        rigidbodyBase = GetComponent<Rigidbody>();
        transformBase = GetComponent<Transform>();

        timeRemainingReturnToPoolCollision = new TimeRemaining(ReturnToPoolCollision, _timeReturnToPoolCollision);
        timeRemainingReturnToPoolParticle = new TimeRemaining(ReturnToPoolParticle, _timeReturnToPoolParticle);
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