using UnityEngine;


public sealed class BotGreen : BotBase
{
    private readonly string _destroyBotParticleGreen = "DestroyBotGreenParticle_1";
    private readonly string _destroyBotCollisionGreen = "GreenRingImpact";

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
        collisionObject = PoolManager.GetObject(_destroyBotCollisionGreen, ball.transform.position, Quaternion.identity);
        particleObject = PoolManager.GetObject(_destroyBotParticleGreen, ball.transform.position, Quaternion.identity);

        ReturnToPool();
    }
}