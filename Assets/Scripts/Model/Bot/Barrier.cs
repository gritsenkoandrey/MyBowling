using UnityEngine;


public sealed class Barrier : BaseModel
{
    private void OnTriggerEnter(Collider obj)
    {
        ball = obj.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            gameObject.SetActive(false);
            ball.DestroyBall();
        }
    }
}