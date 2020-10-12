using UnityEngine;


public sealed class BallModel : MonoBehaviour
{
    [Range(0.0f, 5.0f), SerializeField] private float _destroyBallByTime = 0.0f;
    [Range(0.0f, 200.0f), SerializeField] private float _forceBall = 100.0f;
    public static bool IsActive;
    private Vector3 _speedBall;

    [SerializeField] private GameObject _destroyBallParticle = null;
    private Rigidbody _ballRigidbody;

    [SerializeField] private BallType _ball = BallType.NormalBall;

    private void Start()
    {
        _speedBall = new Vector3(0.0f, 0.0f, _forceBall);
        _ballRigidbody = GetComponent<Rigidbody>();
        _ballRigidbody.useGravity = false;
        IsActive = false;
    }

    public void ShootingBall(Vector2 direction)
    {
        if (IsActive == false && _ball == BallType.NormalBall)
        {
            _ballRigidbody.useGravity = true;
            _ballRigidbody.AddForce(Quaternion.LookRotation
                (new Vector3(direction.x, 0, direction.y)) * _speedBall, ForceMode.VelocityChange);
            IsActive = true;
            Invoke(nameof(DestroyBall), _destroyBallByTime);
        }

        if (IsActive == false && _ball == BallType.ExplodingBall)
        {
            return;
        }
    }

    public void DestroyBall()
    {
        BallSpawner.IsBallAlive = false;
        Instantiate(_destroyBallParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}