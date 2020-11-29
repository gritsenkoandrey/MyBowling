using UnityEngine;


public sealed class Bot : BotBase
{
    private readonly string _destroyBotCollision = "ModularRingImpact";
    private readonly string _destroyBotDollParticle = "FX_StarStunned_02";

    private void OnTriggerEnter(Collider other)
    {
        ball = other.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            DestroyBotWithBall();
        }
    }

    public override void DestroyBotWithBall()
    {
        collisionObject = PoolManager.GetObject(_destroyBotCollision, ball.transform.position, Quaternion.identity);
        particleObject = PoolManager.GetObject(_destroyBotDollParticle, ball.transform.position, Quaternion.identity);
        ReturnToPool();
    }
}