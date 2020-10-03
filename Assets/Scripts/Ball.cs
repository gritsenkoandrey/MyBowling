using Assets.Scripts;
using UnityEngine;


public sealed class Ball : MonoBehaviour
{
    [Range(0.5f, 10.0f), SerializeField] private float _destroyBallByTime = 0.0f;
    [SerializeField] private GameObject _destroyBallParticle;

    private UiShowBallTrajectory _ballTrajectory;

    private Camera _mainCamera;
    private Rigidbody _ball;
    private KeyCode _leftMouseButton = KeyCode.Mouse0;
    private Ray _ray;
    private Vector3 _speed;
    private Vector3 _startPos;
    private bool _isActive;
    private readonly float _force = 100.0f;

    private void Start()
    {
        _mainCamera = FindObjectOfType<Camera>();
        _ballTrajectory = FindObjectOfType<UiShowBallTrajectory>();
        _ball = GetComponent<Rigidbody>();
        _speed = new Vector3(0.0f, 0.0f, _force);
        _ball.useGravity = false;
        _isActive = false;
        _startPos = transform.position;
    }

    private void Update()
    {
        _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (_isActive == false)
        {
            Debug.DrawLine(_startPos, _ray.origin, Color.red);
            _ballTrajectory.SliderDisplay(true);
        }

        if (Input.GetKey(_leftMouseButton))
        {
            _ballTrajectory.SliderCalculate(_ray);
        }

        if (Input.GetKeyUp(_leftMouseButton))
        {
            if (_isActive == false)
            {
                _ball.useGravity = true;
                _ball.AddForce(Quaternion.LookRotation(_ray.direction) * _speed,
                    ForceMode.Impulse);
                _isActive = true;
                _ballTrajectory.SliderDisplay(false);
                _ballTrajectory.SliderValueReset();
                Invoke(nameof(DestroyBallByTime), _destroyBallByTime);
            }
        }
    }

    public void DestroyBallByTime()
    {
        BallSpawner.isBallAlive = false;
        Instantiate(_destroyBallParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}