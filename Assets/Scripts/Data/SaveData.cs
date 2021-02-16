using Scripts;

public static class SaveData
{
    private static string _maxScore = "Score";
    private static string _curScore = "CurrentScore";

    public static void SaveMaximumScore()
    {
        if (Services.Instance.SaveData.GetInt(_maxScore) < LevelController.CountScore)
        {
            Services.Instance.SaveData.SetInt(_maxScore, LevelController.CountScore);
        }
    }

    public static void SaveCurrentScore()
    {
        Services.Instance.SaveData.SetInt(_curScore, LevelController.CountScore);
    }

    public static int LoadMaximumScore()
    {
        return Services.Instance.SaveData.GetInt(_maxScore);
    }

    public static int LoadCurrentScore()
    {
        return Services.Instance.SaveData.GetInt(_curScore);
    }

    public static void CleanData()
    {
        Services.Instance.SaveData.DeleteAll();
    }
}
