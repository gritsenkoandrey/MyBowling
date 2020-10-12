using UnityEngine;


public sealed class GameBoundary : MonoBehaviour
{
    [SerializeField] private GameObject _destroyBallParticle = null;
    private BallModel _ball;

    private void OnTriggerExit(Collider other)
    {
        _ball = other.GetComponent<BallModel>();

        if (_ball)
        {
            Instantiate(_destroyBallParticle, _ball.transform.position, Quaternion.identity);
            Destroy(_ball.gameObject);
            BallSpawner.IsBallAlive = false;
        }
    }
}