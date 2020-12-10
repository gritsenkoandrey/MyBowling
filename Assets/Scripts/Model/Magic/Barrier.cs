using UnityEngine;


[RequireComponent(typeof(PoolObject))]
public sealed class Barrier : BaseModel
{
    private void OnTriggerEnter(Collider obj)
    {
        ball = obj.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            ball.DestroyBall();
            gameObject.GetComponent<PoolObject>().ReturnToPool();
        }
    }
}