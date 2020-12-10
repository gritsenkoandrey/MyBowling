using Scripts;
using UnityEngine;


[CreateAssetMenu(fileName = "BallData", menuName = "Data/Ball/BallData")]
public sealed class BallData : ScriptableObject
{
    public Vector3 spawnBallPosition;

    public void SpawnBall()
    {
        PoolManager.GetObject(Data.Instance.PrefabsData.ballPrefab, spawnBallPosition, Quaternion.identity);
    }
}