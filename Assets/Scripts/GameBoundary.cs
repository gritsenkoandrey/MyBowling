using UnityEngine;


public sealed class GameBoundary : MonoBehaviour
{
    [SerializeField] private GameObject _destroyBallParticle;
    private Ball _ball;

    private void OnTriggerExit(Collider other)
    {
        _ball = other.GetComponent<Ball>();
        if (_ball)
        {
            Instantiate(_destroyBallParticle, _ball.transform.position, Quaternion.identity);
            Destroy(_ball.gameObject);
            BallSpawner.isBallAlive = false;
        }
    }
}