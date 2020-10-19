using Scripts;
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
        prefabOne = PoolManager.GetObject(_destroyBotCollisionCowboy, ball.transform.position, Quaternion.identity);
        prefabTwo = PoolManager.GetObject(_destroyBotParticleCowboy, ball.transform.position, Quaternion.identity);

        timeRemainingReturnToPoolOne.AddTimeRemaining();
        timeRemainingReturnToPoolTwo.AddTimeRemaining();

        timeRemainingDestroyBot.AddTimeRemaining();
    }

    public override void DestroyBotWithParticle()
    {
        prefabOne = PoolManager.GetObject(_destroyBotCollisionCowboy, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.0f, gameObject.transform.position.z), Quaternion.identity);
        prefabTwo = PoolManager.GetObject(_destroyBotParticleCowboy, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.0f, gameObject.transform.position.z), Quaternion.identity);

        timeRemainingReturnToPoolOne.AddTimeRemaining();
        timeRemainingReturnToPoolTwo.AddTimeRemaining();

        timeRemainingDestroyBot.AddTimeRemaining();
    }
}