using UnityEngine;


public sealed class UiInterface
{
    private UiShowBallTrajectory _uiShowBallTrajectory;

    public UiShowBallTrajectory UiShowBall
    {
        get
        {
            if (!_uiShowBallTrajectory)
            {
                _uiShowBallTrajectory = Object.FindObjectOfType<UiShowBallTrajectory>();
            }
            return _uiShowBallTrajectory;
        }
    }
}