using UnityEngine;


public sealed class BallController : BaseController, IExecute, IInitialization
{
    private BallSpawner _ballSpawner;

    public void Initialization()
    {
        _ballSpawner = Object.FindObjectOfType<BallSpawner>();
    }

    public void Execute()
    {
        _ballSpawner.SpawnBall();
    }
}