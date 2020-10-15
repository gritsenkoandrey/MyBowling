using UnityEngine;


public class AimModel : MonoBehaviour
{
    [SerializeField] private GameObject _destroyAimParticle = null;
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
        Instantiate(_destroyAimParticle, _ball.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}