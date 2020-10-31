using UnityEngine;
using DG.Tweening;
using System;

public sealed class CameraShake : BaseModel
{
    [Range(0.0f, 10.0f), SerializeField] private float _duration = 0.0f;
    [Range(0.0f, 3.0f), SerializeField] private float _strength = 0.0f;
    [Range(0.0f, 90.0f), SerializeField] private float _randomness = 0.0f;
    [Range(0, 10), SerializeField] private int _vibrato = 0;

    //public event Action<CameraShake> OnCameraShake;

    protected override void Awake()
    {
        base.Awake();
        transformBase = Camera.main.transform;
    }

    public void CreateShake()
    {
        //OnCameraShake?.Invoke(this);
        DOTween.Shake(() => transformBase.position, pos =>
        transformBase.position = pos, _duration, _strength, _vibrato, _randomness);
    }
}