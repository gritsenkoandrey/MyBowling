using UnityEngine;


public sealed class BotDoll : BotBase
{
    private readonly string _destroyBotCollision = "ModularRingImpact";
    //private readonly string _destroyBotDollParticle = "DestroyBotDollParticle";
    private readonly string _destroyBotDollParticle = "BloodSplat";

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

    public override void DestroyBotWithParticle()
    {
        collisionObject = PoolManager.GetObject(_destroyBotCollision, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + spawnCorrection, gameObject.transform.position.z), Quaternion.identity);
        particleObject = PoolManager.GetObject(_destroyBotDollParticle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + spawnCorrection, gameObject.transform.position.z), Quaternion.identity);

        ReturnToPool();
    }
}