using Scripts;
using UnityEngine;


public sealed class AimWood : AimBase
{
    private void OnTriggerEnter(Collider other)
    {
        ball = other.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            DestroyAimParticle();
        }
    }

    public override void DestroyAimParticle()
    {
        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyWoodParticle, ball.transform.position, Quaternion.identity);
        ReturnToPool();
    }
}