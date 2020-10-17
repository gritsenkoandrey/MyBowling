using UnityEngine;


public abstract class AimBase : BaseModel
{
    [SerializeField] private GameObject _destroyAimParticle = null;

    public void DestroyAimParticle()
    {
        Instantiate(_destroyAimParticle, ball.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}