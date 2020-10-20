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
        collisionObj = PoolManager.GetObject(destroyBotCollisionCowboy, ball.transform.position, Quaternion.identity);
        particleObj = PoolManager.GetObject(destroyBotParticleCowboy, ball.transform.position, Quaternion.identity);

        ReturnToPool();
    }

    public override void DestroyBotWithParticle()
    {
        collisionObj = PoolManager.GetObject(destroyBotCollisionCowboy, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + posYSpawnCorrection, gameObject.transform.position.z), Quaternion.identity);
        particleObj = PoolManager.GetObject(destroyBotParticleCowboy, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + posYSpawnCorrection, gameObject.transform.position.z), Quaternion.identity);

        ReturnToPool();
    }
}