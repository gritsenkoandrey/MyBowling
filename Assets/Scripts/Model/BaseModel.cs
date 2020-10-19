using Scripts;
using UnityEngine;


public abstract class BaseModel : MonoBehaviour
{
    protected GameObject prefabOne;
    protected GameObject prefabTwo;

    protected Rigidbody rigidbodyBase;
    protected Transform transformBase;

    protected BotBase bot;
    protected BallBase ball;
    protected AimBase aim;

    protected TimeRemaining timeRemainingReturnToPoolOne;
    protected TimeRemaining timeRemainingReturnToPoolTwo;

    private readonly float _timeReturnToPoolOne = 3.0f;
    private readonly float _timeReturnToPoolTwo = 5.0f;

    protected virtual void Awake()
    {
        rigidbodyBase = GetComponent<Rigidbody>();
        transformBase = GetComponent<Transform>();

        timeRemainingReturnToPoolOne = new TimeRemaining(ReturnToPoolOne, _timeReturnToPoolOne);
        timeRemainingReturnToPoolTwo = new TimeRemaining(ReturnToPoolTwo, _timeReturnToPoolTwo);
    }

    private void ReturnToPoolOne()
    {
        prefabOne.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingReturnToPoolOne.RemoveTimeRemaining();
    }

    private void ReturnToPoolTwo()
    {
        prefabTwo.GetComponent<PoolObject>().ReturnToPool();
        timeRemainingReturnToPoolTwo.RemoveTimeRemaining();
    }
}