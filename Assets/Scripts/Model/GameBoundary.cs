using UnityEngine;


public sealed class GameBoundary : MonoBehaviour
{
    private BallModel _ball;

    private void OnTriggerExit(Collider other)
    {
        _ball = other.GetComponent<BallModel>();

        if (_ball)
        {
            _ball.DestroyBall();
        }
    }
}