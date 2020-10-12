using UnityEngine;


public sealed class BallController : IExecute, IInitialization
{
    private readonly int _leftButton = (int)MouseButton.LeftButton;
    private float _angle = 0.0f;
    private Vector2 _direction;

    private BallModel _ballModel;
    private BallSpawner _ballSpawner;
    private UiShowBallTrajectory _uiShowBallTrajectory;
    private Camera _mainCamera;

    public void Initialization()
    {
        _mainCamera = Object.FindObjectOfType<Camera>();

        _ballSpawner = Object.FindObjectOfType<BallSpawner>();
        _uiShowBallTrajectory = Object.FindObjectOfType<UiShowBallTrajectory>();
    }

    public void Execute()
    {
        _ballSpawner.SpawnBall();

        if (Input.GetMouseButton(_leftButton))
        {
            _ballModel = Object.FindObjectOfType<BallModel>();
            _direction = Input.mousePosition - _mainCamera.WorldToScreenPoint(_ballModel.transform.position);

            if (BallModel.IsActive == false)
            {
                _angle = -Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg;
                _uiShowBallTrajectory.SliderDisplay(true);
                _uiShowBallTrajectory.SliderCalculate(_angle, _direction.y);
            }
        }

        if (Input.GetMouseButtonUp(_leftButton))
        {
            if (_ballModel != null)
            {
                _ballModel.ShootingBall(_direction);
                _uiShowBallTrajectory.SliderDisplay(false);
                _uiShowBallTrajectory.SliderValueReset();
            }
        }
    }
}