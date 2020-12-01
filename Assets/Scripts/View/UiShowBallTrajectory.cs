using UnityEngine;
using UnityEngine.UI;


public sealed class UiShowBallTrajectory : MonoBehaviour
{
    //private readonly float _maxValue = 30.0f;
    //private readonly float _minValue = 1.0f;
    private float _angle;

    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.gameObject.SetActive(false);
        //_slider.minValue = _minValue;
        //_slider.maxValue = _maxValue;
    }

    public void ShowDirectionBall(Vector2 dir)
    {
        if (Ball.IsLaunch == false)
        {
            _angle = -Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

            SliderDisplay(true);
            SliderCalculate(_angle, dir.y);
        }
    }

    public void HideDirectionBall()
    {
        if (Ball.IsLaunch == true)
        {
            SliderDisplay(false);
            SliderValueReset();
        }
    }

    private void SliderCalculate(float angle, float dir)
    {
        _slider.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, angle);
        //_slider.value = dir / _maxValue;
    }

    private void SliderDisplay(bool value)
    {
        _slider.gameObject.SetActive(value);
    }

    private void SliderValueReset()
    {
        //_slider.value = _minValue;
        _slider.GetComponent<RectTransform>().localRotation = Quaternion.identity;
    }
}