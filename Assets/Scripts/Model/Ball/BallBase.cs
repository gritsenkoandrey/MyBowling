using Scripts;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(SphereCollider), typeof(PoolObject))]
public abstract class BallBase : BaseModel
{
    public static BallBase Instance;

    [Range(0.0f, 5.0f), SerializeField] private float _destroyBallByTime = 0.0f;
    [Range(0.0f, 2000.0f), SerializeField] private float _forceBall = 0.0f;

    private readonly byte _minHitCounter = 1;
    private int _hitCounter;
    private bool _isLaunch;
    private bool _isBallAlive;

    protected Vector3 speedBall;
    protected Rigidbody myBody;
    protected TimeRemaining timeRemainingDestroyBall;

    public bool IsLaunch { get { return _isLaunch; } set { _isLaunch = value; } }
    public bool IsBallAlive { get { return _isBallAlive; } set { _isBallAlive = value; } }
    public int HitCounter { get { return _hitCounter; } set { _hitCounter = value; } }

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
        HitCounter = _minHitCounter;
        timeRemainingDestroyBall = new TimeRemaining(DestroyBall, _destroyBallByTime);
    }

    private void OnDisable()
    {
        myBody.velocity = Vector3.zero;
        myBody.angularVelocity = Vector3.zero;
    }

    public abstract void Launch(Vector3 dir);

    public void DestroyBall()
    {
        IsBallAlive = false;
        IsLaunch = false;
        Services.Instance.AudioService.PlaySound(AudioName.EXPLOSION_BALL);
        collisionObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyBallCollision,
            gameObject.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolCollision.AddTimeRemaining();

        timeRemainingDestroyBall.RemoveTimeRemaining();
        gun.FireOff();
        gun.FireParticleOff();
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }
}