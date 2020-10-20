using UnityEngine;


public sealed class BotGreen : BotBase
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
        prefabOne = PoolManager.GetObject(destroyBotCollisionGreen, ball.transform.position, Quaternion.identity);
        prefabTwo = PoolManager.GetObject(destroyBotParticleGreen, ball.transform.position, Quaternion.identity);
        ReturnToPool();
    }

    public override void DestroyBotWithParticle()
    {
        prefabOne = PoolManager.GetObject(destroyBotCollisionGreen,
            new Vector3(gameObject.transform.position.x, 
            gameObject.transform.position.y + posYSpawnCorrection, gameObject.transform.position.z), Quaternion.identity);
        prefabTwo = PoolManager.GetObject(destroyBotParticleGreen,
            new Vector3(gameObject.transform.position.x, 
            gameObject.transform.position.y + posYSpawnCorrection, gameObject.transform.position.z), Quaternion.identity);
        ReturnToPool();
    }
}