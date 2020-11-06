using Scripts;
using UnityEngine;


public sealed class BuildingBase : BaseModel
{
    [SerializeField] private int _health = 0;

    private readonly string _buildingDestroyParticle = "DestroyObjParticle_3";
    private readonly string _buildingCollision = "Impact_Wood_01";
    private readonly string _buildingParticleDestroyWhenLevelClean = "FX_Explosion_01";

    private void OnCollisionEnter(Collision collision)
    {
        ball = collision.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            _health--;
            collisionObject = PoolManager.GetObject(_buildingCollision,
                ball.transform.position, Quaternion.identity);
            timeRemainingReturnToPoolCollision.AddTimeRemaining();

            if (_health <= 0)
            {
                gameObject.GetComponent<PoolObject>().ReturnToPool();

                particleObject = PoolManager.GetObject(_buildingDestroyParticle,
                    ball.transform.position, Quaternion.identity);
                timeRemainingReturnToPoolParticle.AddTimeRemaining();
            }
        }
    }

    public void DestroyBuildingWhenLevelClean()
    {
        this.gameObject.GetComponent<PoolObject>().ReturnToPool();
        particleObject = PoolManager.
            GetObject(_buildingParticleDestroyWhenLevelClean, gameObject.transform.position, Quaternion.identity);

        timeRemainingReturnToPoolParticle.AddTimeRemaining();
    }
}