using UnityEngine;


[CreateAssetMenu(fileName = "BallData", menuName = "Data/Ball/BallData")]
public sealed class BallData : ScriptableObject
{
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private BallBase _ball = null;

    public void SpawnBall()
    {
        Instantiate(_ball, _spawnPosition, Quaternion.identity);
    }
}