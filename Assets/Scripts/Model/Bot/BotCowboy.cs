﻿using UnityEngine;


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
        prefabOne = PoolManager.GetObject(destroyBotCollisionCowboy, ball.transform.position, Quaternion.identity);
        prefabTwo = PoolManager.GetObject(destroyBotParticleCowboy, ball.transform.position, Quaternion.identity);
        ReturnToPool();
    }

    public override void DestroyBotWithParticle()
    {
        prefabOne = PoolManager.GetObject(destroyBotCollisionCowboy,
            new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y + hightCorrection, gameObject.transform.position.z), Quaternion.identity);
        prefabTwo = PoolManager.GetObject(destroyBotParticleCowboy,
            new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y + hightCorrection, gameObject.transform.position.z), Quaternion.identity);
        ReturnToPool();
    }
}