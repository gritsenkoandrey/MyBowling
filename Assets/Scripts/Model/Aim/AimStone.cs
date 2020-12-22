using Scripts;
using UnityEngine;


public sealed class AimStone : AimBase
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
        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyStoneParticle, ball.transform.position, Quaternion.identity);

        DestroyAim();
    }

    public override void DestroyAimWithBomb()
    {
        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyStoneParticle, gameObject.transform.position, Quaternion.identity);
        DestroyAim();
    }
}