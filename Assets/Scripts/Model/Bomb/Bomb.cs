using Scripts;
using UnityEngine;


public sealed class Bomb : BombBase
{
    private void OnTriggerEnter(Collider other)
    {
        ball = other.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            ball.DestroyBall();

            countColliders = Physics.OverlapSphereNonAlloc(gameObject.transform.position, radius, hitColliders, targetLayer);

            for (int i = 0; i < countColliders; i++)
            {
                if (hitColliders[i].TryGetComponent(out bot))
                {
                    bot.DestroyBotWithBomb();
                }
                else if (hitColliders[i].TryGetComponent(out aim))
                {
                    aim.DestroyAimWithBomb();
                }
                else if (hitColliders[i].TryGetComponent(out building))
                {
                    building.BuildingDestroyWithBomb();
                }
                //todo? (hitColliders[i].TryGetComponent(out bomb))
            }
            ExplodedBomb();
        }
    }

    public override void ExplodedBomb()
    {
        particleObject = PoolManager.GetObject(Data.Instance.PrefabsData.bombExplosion,
            gameObject.transform.position, Quaternion.identity);
        DestroyBomb();
    }
}