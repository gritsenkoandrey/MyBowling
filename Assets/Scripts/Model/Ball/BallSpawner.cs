using UnityEngine;


public sealed class BallSpawner : BaseModel
{
    [SerializeField] private BallBase _prefabBall = null;
    [SerializeField] private Vector3 _spawnPosition = Vector3.zero;

    //private readonly string _ball = "Ball_2";

    public static bool IsBallAlive = false;

    public void SpawnBall()
    {
        if (IsBallAlive == false)
        {
            //prefabTwo = PoolManager.GetObject(_ball, _spawnPosition, Quaternion.identity);
            Instantiate(_prefabBall, _spawnPosition, Quaternion.identity);
            IsBallAlive = true;
        }
    }
}