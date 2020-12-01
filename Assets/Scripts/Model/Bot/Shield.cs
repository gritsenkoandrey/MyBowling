using UnityEngine;
using Scripts;


public sealed class Shield : BaseModel
{
    private void OnCollisionEnter(Collision obj)
    {
        ball = obj.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            DestroyShield();
        }
    }

    private void DestroyShield()
    {
        gameObject.SetActive(false);

        collisionObject = PoolManager.GetObject(Data.Instance.PrefabsData.impactCollision, ball.transform.position, Quaternion.identity);
        timeRemainingReturnToPoolCollision.AddTimeRemaining();
    }
}