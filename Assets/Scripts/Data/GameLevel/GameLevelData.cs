using UnityEngine;


[CreateAssetMenu(fileName = "GameLevelData", menuName = "Data/GameLevel/GameLevelData")]
public class GameLevelData : ScriptableObject
{
    [SerializeField] private SerializeGameLevelData[] _gameLevel;

    public GameLevelInfo GetGameLevelInfo(GameLevelType type)
    {
        GameLevelInfo result = default;

        foreach (var gameLevelData in _gameLevel)
        {
            if (gameLevelData.GameLevelType == type)
            {
                result = gameLevelData.GameLevelInfo;
            }
        }

        return result;
    }
}