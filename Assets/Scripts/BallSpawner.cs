using UnityEngine;


public sealed class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Ball _prefab;

    public static bool isBallAlive = false;

    private void Update()
    {
        if (isBallAlive == false)
        {
            Instantiate(_prefab, _spawnPosition);
            isBallAlive = true;
        }
    }
}