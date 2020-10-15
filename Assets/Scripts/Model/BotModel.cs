using UnityEngine;


public sealed class BotModel : MonoBehaviour
{
    [Range(0.0f, 5.0f), SerializeField] private float _destroyBotByTime = 0.0f;

    [SerializeField] private GameObject _destroyBotParticle = null;
    [SerializeField] private GameObject _botCollisionParticle = null;
    private BallModel _ball;
    private CameraShake _shake;

    private void Start()
    {
        _shake = FindObjectOfType<CameraShake>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _ball = other.gameObject.GetComponent<BallModel>();

        if (_ball)
        {
            DestroyBotParticle();
            Invoke(nameof(DestroyBot), _destroyBotByTime);
        }
    }

    public void DestroyBot()
    {
        _shake.CreateShake();
        Destroy(this.gameObject);
    }

    public void DestroyBotParticle()
    {
        if (_ball)
        {
            Instantiate(_destroyBotParticle, _ball.transform.position, Quaternion.identity);
            Instantiate(_botCollisionParticle, _ball.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_destroyBotParticle, gameObject.transform.position, Quaternion.identity);
            Instantiate(_botCollisionParticle, gameObject.transform.position, Quaternion.identity);
        }
    }
}