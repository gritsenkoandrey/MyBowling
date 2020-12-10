using System;
using UnityEngine;


[Serializable]
public struct PlatformInfo
{
    [Header("Spawn points of platforms by coordinate Z")]
    public float[] startPositionPlatforms;
    public float currentPositionPlatform;
    public float destroyPositionPlatform;

    [Header("Number of platforms")]
    public int maxPlatformCount;
    public int minPlatformCount;
    [HideInInspector] public int currentPlatformCount;

    [Header("Movement of platforms")]
    public float delay;
    public float duration;
    [HideInInspector] public float speedPlatform;

    [Header("UI")]
    public bool gameOver;
    public bool nextLevel;
}