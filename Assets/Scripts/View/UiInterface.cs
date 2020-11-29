using UnityEngine;


public sealed class UiInterface
{
    private UiShowBallTrajectory _uiShowBallTrajectory;
    private UiShowScore _uiShowScore;
    private UiShowApplyDamage _uiShowApplyDamage;
    private UiShowLevel _uiShowLevel;
    private UiGameScreen _uiGameScreen;

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

    public UiShowScore UiShowScore
    {
        get
        {
            if (!_uiShowScore)
            {
                _uiShowScore = Object.FindObjectOfType<UiShowScore>();
            }
            return _uiShowScore;
        }
    }

    public UiShowApplyDamage UiShowApplyDamage
    {
        get
        {
            if (!_uiShowApplyDamage)
            {
                _uiShowApplyDamage = Object.FindObjectOfType<UiShowApplyDamage>();
            }
            return _uiShowApplyDamage;
        }
    }

    public UiShowLevel UiShowLevel
    {
        get
        {
            if (!_uiShowLevel)
            {
                _uiShowLevel = Object.FindObjectOfType<UiShowLevel>();
            }
            return _uiShowLevel;
        }
    }

    public UiGameScreen UiGameScreen
    {
        get
        {
            if (!_uiGameScreen)
            {
                _uiGameScreen = Object.FindObjectOfType<UiGameScreen>();
            }
            return _uiGameScreen;
        }
    }
}