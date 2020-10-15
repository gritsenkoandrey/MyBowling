using UnityEngine;


public class AimModel : MonoBehaviour
{
    [SerializeField] private GameObject _destroyAimParticle = null;
    [SerializeField] private Transform _spawnParticle = null;
    private BallModel _ball;

    private void OnTriggerEnter(Collider other)
    {
        _ball = other.gameObject.GetComponent<BallModel>();

        if (_ball)
        {
            _ball.DestroyBall();
            DestroyAimParticle();
        }
    }

    private void DestroyAimParticle()
    {
        //if (_spawnParticle)
        //{
        //    Instantiate(_destroyAimParticle, _spawnParticle.transform.position, Quaternion.identity);
        //}
        //else
        //{
        //    Instantiate(_destroyAimParticle, _ball.transform.position, Quaternion.identity);
        //}

        Instantiate(_destroyAimParticle, _ball.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}