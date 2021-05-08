using Scripts;
using UnityEngine;


public sealed class InputController : BaseController, IExecute
{
    private readonly int _leftButton = (int)MouseButton.LeftButton;
    private readonly KeyCode _escape = KeyCode.Escape;

    private BallBase _ball;
    private Vector3 _direction;

    #region IExecute

    public void Execute()
    {
#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR || UNITY_WSA

        if (Input.GetMouseButton(_leftButton) && uiInterface.UiGameScreen.IsShowUI == false)
        {
            // вызывается один раз
            if (_ball == null)
            {
                _ball = Object.FindObjectOfType<BallBase>();
            }

            if (_ball != null)
            {
                CalculateDirection();
                uiInterface.UiShowBall.ShowDirectionBall(_direction);
            }
        }

        if (Input.GetMouseButtonUp(_leftButton) && uiInterface.UiGameScreen.IsShowUI == false)
        {
            if (_ball != null)
            {
                _ball.Launch(_direction);
            }

            uiInterface.UiShowBall.HideDirectionBall();
        }

        if (Input.GetKeyDown(_escape))
        {
            return;
        }
#endif

#if UNITY_IOS || UNITY_ANDROID

        if (Input.touchCount > 0 && uiInterface.UiGameScreen.IsShowUI == false)
        {
            // Debug.Log(Input.touchCount); - количество прикосновений
            if (Input.touches[0].phase == TouchPhase.Began) // Палец коснулся экрана
            {
                if (_ball == null)
                {
                    _ball = Object.FindObjectOfType<BallBase>();
                }
            }

            if (Input.touches[0].phase == TouchPhase.Ended) // Палец был снят с экрана
            {
                if (_ball != null)
                {
                    _ball.Launch(_direction);
                }
                uiInterface.UiShowBall.HideDirectionBall();
            }

            if (Input.touches[0].phase == TouchPhase.Moved) // Палец перемещается по экрану
            {
                if (_ball != null)
                {
                    CalculateDirection();
                    uiInterface.UiShowBall.ShowDirectionBall(_direction);
                }
            }

            if (Input.touches[0].phase == TouchPhase.Stationary) // Палец прикоснулся к экрану, но не сдвинулся
            {
                if (_ball != null)
                {
                    CalculateDirection();
                    uiInterface.UiShowBall.ShowDirectionBall(_direction);
                }
            }
        }
#endif
    }

    private Vector3 CalculateDirection()
    {
        Ray ray = Services.Instance.CameraServices.CameraMain.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _direction = (hit.point - _ball.transform.position).normalized;
            _direction.y = 0f;
        }

        return _direction;
    }

    #endregion
}