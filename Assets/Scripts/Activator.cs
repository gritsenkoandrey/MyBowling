using UnityEngine;
using DG.Tweening;


namespace Assets.Scripts
{
    public enum DestroyBall
    {
        None,
        Destroy
    }

    public sealed class Activator : MonoBehaviour
    {
        [SerializeField] private WallActivator _wall;
        [SerializeField] private GameObject _particleCollision;
        [SerializeField] private Ease _ease;
        [SerializeField] private Color _targetColor;
        [SerializeField] private Vector3 _targetPos = Vector3.zero;
        [SerializeField] private DestroyBall _destroyBallType = DestroyBall.Destroy;
        [Range(1.0f, 10.0f), SerializeField] private float _colorChangeDuration = 1.0f;
        [Range(0.5f, 10.0f), SerializeField] private float _moveDuration = 1.0f;

        private Ball _ball;

        private void OnTriggerEnter(Collider other)
        {
            _ball = other.gameObject.GetComponent<Ball>();

            if (_ball)
            {
                DOTween.Sequence()
                    .Append(transform.GetComponent<Renderer>().material
                    .DOColor(_targetColor, _colorChangeDuration).SetEase(_ease));
                _wall.MoveWall(_targetPos, _moveDuration, _ease);
                Instantiate(_particleCollision, gameObject.transform.position, Quaternion.identity);
                if (_destroyBallType == DestroyBall.Destroy)
                {
                    BallSpawner.isBallAlive = false;
                    Destroy(_ball.gameObject);
                }
            }
        }
    }
}