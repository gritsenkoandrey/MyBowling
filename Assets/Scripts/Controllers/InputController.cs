using UnityEngine;


public sealed class InputController : BaseController, IExecute
{
    private readonly int _leftButton = (int)MouseButton.LeftButton;
    private readonly KeyCode _escape = KeyCode.Escape;

    private BallBase _ball;
    private Vector2 _direction;

    public InputController()
    {
        Cursor.visible = false;
    }

    #region IExecute

    public void Execute()
    {
        if (Input.GetMouseButton(_leftButton))
        {
            if (_ball == null)
            {
                _ball = Object.FindObjectOfType<BallBase>();
            }

            _direction = Input.mousePosition - mainCamera.WorldToScreenPoint(_ball.transform.position);
            uiInterface.UiShowBall.ShowDirectionBall(_direction);
        }

        if (Input.GetMouseButtonUp(_leftButton))
        {
            _ball.GetComponent<Ball>().Launch(_direction);
            uiInterface.UiShowBall.HideDirectionBall();
        }

        if (Input.GetKeyDown(_escape))
        {
            return;
        }
    }

    #endregion
}