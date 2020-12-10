using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public sealed class UiShowScore : MonoBehaviour
{
    [SerializeField] private float _duration = 0.0f;

    private RectTransform _rectTransform;
    private Text _text;
    private Sequence _sequence;

    public int Text
    {
        set
        {
            _text.text = $"{value}";
        }
    }

    private void Awake()
    {
        _text = GetComponent<Text>();
        _rectTransform = _text.GetComponent<RectTransform>();
    }

    public void SetActive(bool value)
    {
        _text.gameObject.SetActive(value);
    }

    public void EnlargeTextScore()
    {
        _sequence.Insert(0.0f, _rectTransform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.0f));
        _sequence.Append(_rectTransform.DOScale(Vector3.one, _duration));
    }
}