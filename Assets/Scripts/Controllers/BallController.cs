using Scripts;


public sealed class BallController : BaseController, IExecute
{
    public void Execute()
    {
        if (BallBase.Instance.IsBallAlive == false && BallBase.Instance.IsLaunch == false && uiInterface.UiGameScreen.IsShowUI == false)
        {
            Data.Instance.Ball.SpawnBall();
            BallBase.Instance.IsBallAlive = true;
        }
    }
}