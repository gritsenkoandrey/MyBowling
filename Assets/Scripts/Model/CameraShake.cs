using UnityEngine;
using DG.Tweening;


public sealed class CameraShake : MonoBehaviour
{
    [Range(0.0f, 10.0f), SerializeField] private float _duration = 0.0f;
    [Range(0.0f, 3.0f), SerializeField] private float _strength = 0.0f;
    [Range(0.0f, 90.0f), SerializeField] private float _randomness = 0.0f;
    [Range(0, 10), SerializeField] private int _vibrato = 0;

    private Transform _camera;

    private void OnValidate()
    {
        _camera = Camera.main.transform;
    }

    public void CreateShake()
    {
        DOTween.Shake(() => _camera.position, pos =>
        _camera.position = pos, _duration, _strength, _vibrato, _randomness);
    }
}