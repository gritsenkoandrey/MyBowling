﻿using Scripts;
using UnityEngine;


public sealed class Bot : BotBase
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
        collisionObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyBotCollision,
            ball.transform.position, Quaternion.identity);
        DestroyBot();
    }

    public override void DestroyBotWithBomb()
    {
        collisionObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyBotCollision, 
            gameObject.transform.position, Quaternion.identity);
        DestroyBot();
    }
}