﻿using UnityEngine;


public sealed class AimBox : AimBase
{
    private void OnTriggerEnter(Collider other)
    {
        ball = other.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            ball.DestroyBall();
            DestroyAimParticle();
        }
    }

    public override void DestroyAimParticle()
    {
        particleObj = PoolManager.GetObject(_destroyBoxParticle, ball.transform.position, Quaternion.identity);

        ReturnToPool();
    }
}