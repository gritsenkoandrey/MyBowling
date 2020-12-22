using Scripts;
using UnityEngine;


public sealed class BotBig : BotBase
{
    [SerializeField] private int _maxHealth = 0;
    private readonly int _minHealth = 0;
    private int _currentHealth;

    public int Health
    {
        get { return _currentHealth; }
        private set { _currentHealth = value; }
    }

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
        gameObject.transform.localScale = Vector3.one;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ball = collision.gameObject.GetComponent<BallBase>();

        if (ball)
        {
            Health--;
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            if (Health <= _minHealth)
            {
                DestroyBotWithBall();
            }
        }
    }

    public override void DestroyBotWithBall()
    {
        collisionObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyBotCollision,
            ball.transform.position, Quaternion.identity);

        DestroyBot();
    }

    public override void DestroyBotWithBomb()
    {
        collisionObject = PoolManager.GetObject(Data.Instance.PrefabsData.destroyBotCollision, 
            gameObject.transform.position, Quaternion.identity);
        DestroyBot();
    }
}