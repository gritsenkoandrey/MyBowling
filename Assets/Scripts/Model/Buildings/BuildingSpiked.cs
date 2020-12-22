using Scripts;
using UnityEngine;


public class BuildingSpiked : BuildingBase
{
    private void OnCollisionEnter(Collision collision)
    {
        ball = collision.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            Health--;
            ball.DestroyBall();

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
        DestroyBuilding();
    }

    public override void BuildingDestroyWithBomb()
    {
        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyBuildingParticle, 
            gameObject.transform.position, Quaternion.identity);
        DestroyBuilding();
    }
}