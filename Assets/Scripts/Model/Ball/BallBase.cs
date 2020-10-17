using ExampleTemplate;
using UnityEngine;


public abstract class BallBase : BaseModel
{
    [Range(0.0f, 5.0f), SerializeField] private float _destroyBallByTime = 0.0f;
    [Range(0.0f, 200.0f), SerializeField] private float _forceBall = 0.0f;

    public static bool IsLaunch;

    protected Vector3 _speedBall;
    protected TimeRemaining _timeRemaining;

    [SerializeField] private GameObject _destroyBallParticle = null;

    protected void Start()
    {
        _speedBall = new Vector3(0.0f, 0.0f, _forceBall);
        rigidbodyBase.useGravity = false;
        IsLaunch = false;
        _timeRemaining = new TimeRemaining(DestroyBall, _destroyBallByTime);
    }

    public void DestroyBall()
    {
        BallSpawner.IsBallAlive = false;
        Instantiate(_destroyBallParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        _timeRemaining.RemoveTimeRemaining();
    }
}