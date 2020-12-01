using UnityEngine;
using UnityEngine.UI;


public sealed class UiSlider : MonoBehaviour
{
    private Slider _slider;

    public Slider GetSlider
    {
        get
        {
            return _slider;
        }
        set
        {
            _slider = value;
        }
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
}