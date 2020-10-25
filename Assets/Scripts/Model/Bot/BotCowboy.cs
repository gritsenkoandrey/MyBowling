using UnityEngine;


public sealed class BotCowboy : BotBase
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
        collisionObject = PoolManager.GetObject(destroyBotCollisionCowboy, ball.transform.position, Quaternion.identity);
        particleObject = PoolManager.GetObject(destroyBotParticleCowboy, ball.transform.position, Quaternion.identity);

        ReturnToPool();
    }

    public override void DestroyBotWithParticle()
    {
        collisionObject = PoolManager.GetObject(destroyBotCollisionCowboy, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + spawnCorrection, gameObject.transform.position.z), Quaternion.identity);
        particleObject = PoolManager.GetObject(destroyBotParticleCowboy, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + spawnCorrection, gameObject.transform.position.z), Quaternion.identity);

        ReturnToPool();
    }
}