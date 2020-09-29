using UnityEngine;


namespace Assets.Scripts
{
    public sealed class Portal : MonoBehaviour
    {
        [SerializeField] private Transform _exit;
        [SerializeField] private GameObject _particle;
        private Ball _ball;

        private void OnTriggerEnter(Collider other)
        {
            _ball = other.gameObject.GetComponent<Ball>();
            if (_ball)
            {
                Instantiate(_particle, gameObject.transform.position, Quaternion.identity);
                _ball.transform.position = _exit.transform.position;
            }
        }
    }
}