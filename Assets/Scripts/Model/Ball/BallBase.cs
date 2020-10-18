using ExampleTemplate;
using UnityEngine;


public abstract class BallBase : BaseModel
{
    [Range(0.0f, 5.0f), SerializeField] private float _destroyBallByTime = 0.0f;
    [Range(0.0f, 200.0f), SerializeField] private float _forceBall = 0.0f;
    private readonly string _destroyBallParticle = "ModularRingImpact";

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

    public void DestroyBall()
    {
        BallSpawner.IsBallAlive = false;

        prefabOne = PoolManager.GetObject(_destroyBallParticle, gameObject.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolOne.AddTimeRemaining();

        timeRemainingDestroyBall.RemoveTimeRemaining();
        Destroy(this.gameObject);
    }
}