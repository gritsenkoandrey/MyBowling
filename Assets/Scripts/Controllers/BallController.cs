using Scripts;


public sealed class BallController : BaseController, IExecute, IInitialization
{
    public static int CurrentHitCounter;
    public static bool IsBallAlive = false;

    public void Initialization()
    {
        //todo
    }

    public void Execute()
    {
        if (IsBallAlive == false)
        {
            Data.Instance.Ball.SpawnBall();
            IsBallAlive = true;
        }
    }
}