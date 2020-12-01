using Scripts;


public sealed class BallController : BaseController, IExecute
{
    public static int CurrentHitCounter;
    public static bool IsBallAlive = false;

    public void Execute()
    {
        if (IsBallAlive == false)
        {
            Data.Instance.Ball.SpawnBall();
            IsBallAlive = true;
        }
    }
}