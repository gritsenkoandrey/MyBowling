using Scripts;
using UnityEngine;


public class Building : BuildingBase
{
    private void OnCollisionEnter(Collision collision)
    {
        ball = collision.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            Health--;

            if (Health <= minHealth)
            {
                BuildingDestroyParticle();
            }
        }
    }

    public override void BuildingDestroyParticle()
    {
        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyBuildingParticle,
            ball.transform.position, Quaternion.identity);
        ReturnToPool();
    }
}