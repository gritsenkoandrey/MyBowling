using Scripts;
using UnityEngine;


public abstract class BallBase : BaseModel
{
    [Range(0.0f, 5.0f), SerializeField] private float _destroyBallByTime = 0.0f;
    [Range(0.0f, 200.0f), SerializeField] private float _forceBall = 0.0f;

    private readonly string _destroyBallCollision = "ModularRingImpact";

    public static bool IsLaunch;

    protected Vector3 speedBall;

    protected TimeRemaining timeRemainingDestroyBall;

    private void Start()
    {
        speedBall = new Vector3(0.0f, 0.0f, _forceBall);
        rigidbodyBase.useGravity = false;
        IsLaunch = false;

        timeRemainingDestroyBall = new TimeRemaining(DestroyBall, _destroyBallByTime);
    }

    public abstract void Launch(Vector2 dir);

    public void DestroyBall()
    {
        BallSpawner.IsBallAlive = false;

        collisionObject = PoolManager.GetObject(_destroyBallCollision, gameObject.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolCollision.AddTimeRemaining();
        timeRemainingDestroyBall.RemoveTimeRemaining();
        Destroy(this.gameObject);
    }
}