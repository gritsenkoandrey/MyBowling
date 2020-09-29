using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts
{
    public sealed class UiShowBallTrajectory : MonoBehaviour
    {
        [SerializeField] private Transform _canvas;
        [SerializeField] private Slider _slider;
        private Vector3 _dir;
        private float _angle;
        private readonly float _maxValue = 20.0f;
        private readonly float _minValue = 1.0f;
        private float _currentValue;

        private void Start()
        {
            _slider.gameObject.SetActive(false);
            _slider.minValue = _minValue;
            _slider.maxValue = _maxValue;
        }

        public void SliderCalculate(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _dir = new Vector3(hit.point.x - _canvas.position.x, 0.0f, hit.point.z - _canvas.position.z);
                _angle = -Mathf.Atan(_dir.x / _dir.z) * 180 / Mathf.PI;
                _slider.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, _angle);
                _currentValue = hit.point.z - _canvas.position.z;
                _slider.value = _currentValue;
            }
        }

        public void SliderDisplay(bool value)
        {
            _slider.gameObject.SetActive(value);
        }

        public void SliderValueReset()
        {
            _slider.value = _minValue;
            _slider.GetComponent<RectTransform>().localRotation = Quaternion.identity;
        }
    }
}