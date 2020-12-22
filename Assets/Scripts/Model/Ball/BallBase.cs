using Scripts;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(SphereCollider), typeof(PoolObject))]
public abstract class BallBase : BaseModel
{
    public static BallBase Instance;

    [Range(0.0f, 5.0f), SerializeField] private float _destroyBallByTime = 0.0f;
    [Range(0.0f, 2000.0f), SerializeField] private float _forceBall = 0.0f;

    [HideInInspector] public int currentHitCounter;
    private readonly byte _minHitCounter = 1;

    [HideInInspector] public bool isLaunch;
    [HideInInspector] public bool isBallAlive;

    protected Vector3 speedBall;
    protected Rigidbody myBody;
    protected TimeRemaining timeRemainingDestroyBall;

    public BallBase()
    {
        Instance = this;
    }

    protected override void Awake()
    {
        base.Awake();
        myBody = GetComponent<Rigidbody>();
        speedBall = new Vector3(0.0f, 0.0f, _forceBall);
    }

    private void OnEnable()
    {
        myBody.useGravity = false;
        currentHitCounter = _minHitCounter;
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
        isBallAlive = false;
        isLaunch = false;

        collisionObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyBallCollision,
            gameObject.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolCollision.AddTimeRemaining();

        timeRemainingDestroyBall.RemoveTimeRemaining();
        gun.FireOff();
        gun.FireParticleOff();
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }
}