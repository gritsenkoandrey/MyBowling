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
        prefabOne = PoolManager.GetObject(destroyBotCollisionCop, ball.transform.position, Quaternion.identity);
        prefabTwo = PoolManager.GetObject(destroyBotParticleCop, ball.transform.position, Quaternion.identity);
        ReturnToPool();
    }

    public override void DestroyBotWithParticle()
    {
        prefabOne = PoolManager.GetObject(destroyBotCollisionCop,
            new Vector3(gameObject.transform.position.x, 
            gameObject.transform.position.y + hightCorrection,gameObject.transform.position.z), Quaternion.identity);
        prefabTwo = PoolManager.GetObject(destroyBotParticleCop,
            new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y + hightCorrection, gameObject.transform.position.z), Quaternion.identity);
        ReturnToPool();
    }
}