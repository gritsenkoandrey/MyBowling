using UnityEngine;


public sealed class BotCop : BotBase
{
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
        collisionObj = PoolManager.GetObject(destroyBotCollisionCop, ball.transform.position, Quaternion.identity);
        particleObj = PoolManager.GetObject(destroyBotParticleCop, ball.transform.position, Quaternion.identity);

        ReturnToPool();
    }

    public override void DestroyBotWithParticle()
    {
        collisionObj = PoolManager.GetObject(destroyBotCollisionCop, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + posYSpawnCorrection, gameObject.transform.position.z), Quaternion.identity);
        particleObj = PoolManager.GetObject(destroyBotParticleCop, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + posYSpawnCorrection, gameObject.transform.position.z), Quaternion.identity);

        ReturnToPool();
    }
}