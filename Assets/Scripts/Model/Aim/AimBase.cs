using ExampleTemplate;
using UnityEngine;


public abstract class AimBase : BaseModel
{
    [SerializeField] private AimType _aimType = AimType.None;

    private readonly string _destroyTreeParticle = "DestroyObjParticle_2";
    private readonly string _destroyBoxParticle = "DestroyObjParticle_1";

    public void DestroyAimParticle()
    {
        if (_aimType == AimType.Tree)
        {
            prefabTwo = PoolManager.GetObject(_destroyTreeParticle, ball.transform.position, Quaternion.identity);
        }
        else if (_aimType == AimType.Box)
        {
            prefabTwo = PoolManager.GetObject(_destroyBoxParticle, ball.transform.position, Quaternion.identity);
        }
        else
        {
            return;
        }

        timeRemainingReturnToPoolTwo.AddTimeRemaining();

        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }
}