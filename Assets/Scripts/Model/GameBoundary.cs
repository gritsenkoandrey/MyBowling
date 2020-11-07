using UnityEngine;


public sealed class GameBoundary : BaseModel
{
    private void OnTriggerEnter(Collider other)
    {
        ball = other.GetComponent<BallBase>();

        if (ball)
        {
            ball.DestroyBall();
        }
    }
}