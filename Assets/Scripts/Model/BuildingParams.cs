using System;
using DG.Tweening;
using UnityEngine;


[Serializable]
public sealed class BuildingParams
{
    [Range(0.0f, 10.0f)] public float Duration;
    [Range(0.0f, 10.0f)] public float Delay;
    public Ease Ease;
}