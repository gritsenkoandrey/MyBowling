using UnityEngine;


public sealed class AimWooden : AimBase
{
    private readonly string _destroyTreeParticle = "DestroyObjParticle_2";

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
        particleObject = PoolManager.GetObject(_destroyTreeParticle, ball.transform.position, Quaternion.identity);

        ReturnToPool();
    }
}