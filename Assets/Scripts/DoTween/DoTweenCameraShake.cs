using UnityEngine;
using DG.Tweening;


namespace Assets.Scripts.DoTween
{
    public sealed class DoTweenCameraShake : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private float _strength;
        [SerializeField] private int _vibrato;
        [Range(0.0f, 90.0f), SerializeField] private float _randomness;
        [SerializeField] private Transform _camera;

        private void OnValidate()
        {
            _camera = Camera.main.transform;
        }

        public void CreateShake()
        {
            DOTween.Shake(() => _camera.position, pos => _camera.position = pos,
                _duration, _strength, _vibrato, _randomness);
        }
    }
}