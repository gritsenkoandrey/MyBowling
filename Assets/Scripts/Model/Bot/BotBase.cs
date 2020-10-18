using ExampleTemplate;
using UnityEngine;


public abstract class BotBase : BaseModel
{
    [Range(0.0f, 5.0f), SerializeField] private float _destroyBotByTime = 0.0f;

    private readonly string _destroyBotParticleCop = "DestroyBotCopParticle_2";
    private readonly string _destroyBotParticleCowboy = "DestroyBotCowboyParticle_3";
    private readonly string _destroyBotCollisionCop = "BlueRingImpact";
    private readonly string _destroyBotCollisionCowboy = "GreenRingImpact";

    private TimeRemaining _timeRemainingDestroyBot;

    private CameraShake _shake;

    [SerializeField] private BotType botType = BotType.None;

    protected void Start()
    {
        _shake = FindObjectOfType<CameraShake>();

        _timeRemainingDestroyBot = new TimeRemaining(DestroyBot, _destroyBotByTime);
    }

    public void DestroyBotWithBall()
    {

        if (botType == BotType.Cop)
        {
            prefabOne = PoolManager.GetObject(_destroyBotCollisionCop, ball.transform.position, Quaternion.identity);
            prefabTwo = PoolManager.GetObject(_destroyBotParticleCop, ball.transform.position, Quaternion.identity);
        }
        else if (botType == BotType.Cowboy)
        {
            prefabOne = PoolManager.GetObject(_destroyBotCollisionCowboy, ball.transform.position, Quaternion.identity);
            prefabTwo = PoolManager.GetObject(_destroyBotParticleCowboy, ball.transform.position, Quaternion.identity);
        }
        else
        {
            return;
        }

        timeRemainingReturnToPoolOne.AddTimeRemaining();
        timeRemainingReturnToPoolTwo.AddTimeRemaining();

        _timeRemainingDestroyBot.AddTimeRemaining();
    }

    public void DestroyBotWithParticle()
    {
        if (botType == BotType.Cop)
        {
            prefabOne = PoolManager.GetObject(_destroyBotCollisionCop, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.0f, gameObject.transform.position.z), Quaternion.identity);
            prefabTwo = PoolManager.GetObject(_destroyBotParticleCop, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.0f, gameObject.transform.position.z), Quaternion.identity);
        }
        else if (botType == BotType.Cowboy)
        {
            prefabOne = PoolManager.GetObject(_destroyBotCollisionCowboy, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.0f, gameObject.transform.position.z), Quaternion.identity);
            prefabTwo = PoolManager.GetObject(_destroyBotParticleCowboy, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.0f, gameObject.transform.position.z), Quaternion.identity);
        }
        else
        {
            return;
        }

        timeRemainingReturnToPoolOne.AddTimeRemaining();
        timeRemainingReturnToPoolTwo.AddTimeRemaining();

        _timeRemainingDestroyBot.AddTimeRemaining();
    }

    private void DestroyBot()
    {
        _shake.CreateShake();
        gameObject.GetComponent<PoolObject>().ReturnToPool();
        _timeRemainingDestroyBot.RemoveTimeRemaining();
    }
}