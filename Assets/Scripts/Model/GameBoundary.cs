using UnityEngine;


public sealed class GameBoundary : BaseModel
{
    private void OnTriggerExit(Collider other)
    {
        ball = other.GetComponent<BallBase>();

        if (ball)
        {
            ball.DestroyBall();
        }
    }
}