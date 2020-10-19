using Scripts;
using UnityEngine;


public sealed class AimTree : AimBase
{
    private void OnTriggerEnter(Collider other)
    {
        ball = other.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            ball.DestroyBall();
            DestroyAimParticle();
        }
    }

    public override void DestroyAimParticle()
    {
        prefabTwo = PoolManager.GetObject(_destroyTreeParticle, ball.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolTwo.AddTimeRemaining();
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }
}