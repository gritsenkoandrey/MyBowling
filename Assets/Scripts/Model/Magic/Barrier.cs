using Scripts;
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
            DestroyBarrier();
            gameObject.GetComponent<PoolObject>().ReturnToPool();
        }
    }

    private void DestroyBarrier()
    {
        collisionObject = PoolManager.GetObject(Data.Instance.PrefabsData.barrierDestroy,
            gameObject.transform.position, Quaternion.identity);

        timeRemainingReturnToPoolCollision.AddTimeRemaining();
        ResetTransformObject();
    }
}