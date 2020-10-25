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
        collisionObject = PoolManager.GetObject(destroyBotCollisionCop, ball.transform.position, Quaternion.identity);
        particleObject = PoolManager.GetObject(destroyBotParticleCop, ball.transform.position, Quaternion.identity);

        ReturnToPool();
    }

    public override void DestroyBotWithParticle()
    {
        collisionObject = PoolManager.GetObject(destroyBotCollisionCop, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + spawnCorrection, gameObject.transform.position.z), Quaternion.identity);
        particleObject = PoolManager.GetObject(destroyBotParticleCop, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + spawnCorrection, gameObject.transform.position.z), Quaternion.identity);

        ReturnToPool();
    }
}