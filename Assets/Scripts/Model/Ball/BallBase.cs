using Scripts;
using UnityEngine;


public abstract class BallBase : BaseModel
{
    [Range(0.0f, 5.0f), SerializeField] private float _destroyBallByTime = 0.0f;
    [Range(0.0f, 2000.0f), SerializeField] private float _forceBall = 0.0f;

    private readonly byte _minHitCounter = 1;

    private readonly string _destroyBallCollision = "ModularShockwaveImpact";

    public static bool IsLaunch;

    protected Vector3 speedBall;

    protected TimeRemaining timeRemainingDestroyBall;

    private void Start()
    {
        speedBall = new Vector3(0.0f, 0.0f, _forceBall);
        rigidbodyBase.useGravity = false;
        IsLaunch = false;

        //множитель очков, при разрушении шара множитель сбрасывается.
        //нужно переделать!!!
        BallController.CurrentHitCounter = _minHitCounter;

        timeRemainingDestroyBall = new TimeRemaining(DestroyBall, _destroyBallByTime);
    }

    public abstract void Launch(Vector2 dir);

    public void DestroyBall()
    {
        BallController.IsBallAlive = false;
        collisionObject = PoolManager.GetObject(_destroyBallCollision, gameObject.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolCollision.AddTimeRemaining();

        timeRemainingDestroyBall.RemoveTimeRemaining();

        Destroy(this.gameObject);
    }
}