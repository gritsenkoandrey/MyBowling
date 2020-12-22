using Scripts;


public sealed class BallController : BaseController, IExecute
{
    public void Execute()
    {
        if (BallBase.Instance.isBallAlive == false && 
            BallBase.Instance.isLaunch == false && 
            uiInterface.UiGameScreen.isShowUI == false)
        {
            Data.Instance.Ball.SpawnBall();
            BallBase.Instance.isBallAlive = true;
        }
    }
}