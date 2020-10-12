using UnityEngine;


public sealed class BuildingPortal : MonoBehaviour
{
    [SerializeField] private Transform _exitPortal = null;
    [SerializeField] private GameObject _enterPortalParticle = null;
    private BallModel _ball;

    private void OnTriggerEnter(Collider other)
    {
        _ball = other.gameObject.GetComponent<BallModel>();

        if (_ball)
        {
            Instantiate(_enterPortalParticle, gameObject.transform.position, Quaternion.identity);
            _ball.transform.position = _exitPortal.transform.position;
        }
    }
}