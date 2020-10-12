﻿using UnityEngine;


public sealed class BallSpawner : MonoBehaviour
{
    [SerializeField] private BallModel _prefabBall = null;
    [SerializeField] private Vector3 _spawnPosition = Vector3.zero;

    public static bool IsBallAlive = false;

    public void SpawnBall()
    {
        if (IsBallAlive == false)
        {
            Instantiate(_prefabBall, _spawnPosition, Quaternion.identity);
            IsBallAlive = true;
        }
    }
}