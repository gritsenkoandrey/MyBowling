using UnityEngine;
using UnityEngine.UI;


public sealed class UiShowBallTrajectory : MonoBehaviour
{
    private readonly float _maxValue = 30.0f;
    private readonly float _minValue = 1.0f;
    private float _currentValue;

    [SerializeField] private Transform _canvas = null;
    [SerializeField] private Slider _slider = null;

    private void Start()
    {
        _slider.gameObject.SetActive(false);
        _slider.minValue = _minValue;
        _slider.maxValue = _maxValue;
    }

    public void SliderCalculate(float angle, float directionMagnitude)
    {
        _slider.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, angle);
        _currentValue = directionMagnitude / _maxValue;
        _slider.value = _currentValue;
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