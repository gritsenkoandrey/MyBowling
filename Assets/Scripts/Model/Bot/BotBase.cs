using ExampleTemplate;
using UnityEngine;


public abstract class BotBase : BaseModel
{
    [Range(0.0f, 5.0f), SerializeField] private float _destroyBotByTime = 0.0f;

    [SerializeField] private GameObject _destroyBotParticle = null;
    [SerializeField] private GameObject _botCollisionParticle = null;

    private TimeRemaining _timeRemaining;
    private CameraShake _shake;

    protected void Start()
    {
        _shake = FindObjectOfType<CameraShake>();
        _timeRemaining = new TimeRemaining(DestroyBot, _destroyBotByTime);
    }

    public void DestroyBotWithBall()
    {
        Instantiate(_destroyBotParticle, ball.transform.position, Quaternion.identity);
        Instantiate(_botCollisionParticle, ball.transform.position, Quaternion.identity);
        _timeRemaining.AddTimeRemaining();
    }

    public void DestroyBotWithParticle()
    {
        Instantiate(_destroyBotParticle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.0f, gameObject.transform.position.z), Quaternion.identity);
        Instantiate(_botCollisionParticle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.0f, gameObject.transform.position.z), Quaternion.identity);
        _timeRemaining.AddTimeRemaining();
    }

    private void DestroyBot()
    {
        _shake.CreateShake();
        Destroy(this.gameObject);
        _timeRemaining.RemoveTimeRemaining();
    }
}