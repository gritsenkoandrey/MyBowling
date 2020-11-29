using UnityEngine;


public sealed class AimStone : AimBase
{
    private readonly string _destroyBoxParticle = "DestroyObjParticle_1";

    private void OnTriggerEnter(Collider other)
    {
        ball = other.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            health--;

            if (health <= 0)
            {
                DestroyAimParticle();
            }
        }
    }

    public override void DestroyAimParticle()
    {
        particleObject = PoolManager.GetObject(_destroyBoxParticle, ball.transform.position, Quaternion.identity);

        ReturnToPool();
    }
}