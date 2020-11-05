using UnityEngine;


public sealed class BuildingPortal : BaseModel
{
    [SerializeField] private Transform _exitPortal = null;
    [SerializeField] private GameObject _enterPortalParticle = null;

    private void OnTriggerEnter(Collider other)
    {
        ball = other.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            Instantiate(_enterPortalParticle, gameObject.transform.position, Quaternion.identity);
            ball.transform.position = _exitPortal.transform.position;
        }
    }
}