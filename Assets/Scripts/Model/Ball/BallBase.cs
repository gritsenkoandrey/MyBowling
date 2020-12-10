using Scripts;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public abstract class BallBase : BaseModel
{
    [Range(0.0f, 5.0f), SerializeField] private float _destroyBallByTime = 0.0f;
    [Range(0.0f, 2000.0f), SerializeField] private float _forceBall = 0.0f;

    private readonly byte _minHitCounter = 1;

    public static bool IsLaunch;

    protected Vector3 speedBall;
    protected Rigidbody myBody;
    protected TimeRemaining timeRemainingDestroyBall;

    protected override void Awake()
    {
        base.Awake();

        myBody = GetComponent<Rigidbody>();
        speedBall = new Vector3(0.0f, 0.0f, _forceBall);
    }

    private void OnEnable()
    {
        myBody.useGravity = false;
        IsLaunch = false;
        BallController.CurrentHitCounter = _minHitCounter;

        timeRemainingDestroyBall = new TimeRemaining(DestroyBall, _destroyBallByTime);
    }

    private void OnDisable()
    {
        myBody.velocity = Vector3.zero;
        myBody.angularVelocity = Vector3.zero;
    }

    public abstract void Launch(Vector2 dir);

    public void DestroyBall()
    {
        BallController.IsBallAlive = false;

        collisionObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyBallCollision,
            gameObject.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolCollision.AddTimeRemaining();

        timeRemainingDestroyBall.RemoveTimeRemaining();
        gun.FireOff();
        gun.FireParticleOff();
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }
}