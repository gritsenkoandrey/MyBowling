using UnityEngine;
using DG.Tweening;
using TMPro;


public sealed class UiShowApplyDamage : MonoBehaviour
{
    [SerializeField] private UiShowScore _uiShowScore;

    [SerializeField] private TextMeshProUGUI _text = null;
    [SerializeField] private Transform _canvas = null;
    private Sequence _sequence;

    [SerializeField] private float _duaration = 0.0f;

    public void ApplyDamage(Vector3 position, int point)
    {
        LevelController.CountScore += point;
        _uiShowScore.EnlargeTextScore();

        var pos = new Vector3(position.x + Random.Range(-2.0f, 2.0f), position.y + Random.Range(1, 5.0f), position.z);
        var text = Instantiate(_text, pos, Quaternion.identity, _canvas);

        text.text = $"{Mathf.Round(point)}";
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f);

        var rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        _sequence = DOTween.Sequence();

        var posY = rectTransform.anchoredPosition.y + 5.0f;
        _sequence.Append(rectTransform.DOAnchorPosY(posY, _duaration));
        _sequence.Insert(0.0f, rectTransform.DOScale(Vector3.one, _duaration));
        _sequence.Insert(0.0f, text.DOFade(1.0f, _duaration / 2.0f));
        _sequence.Append(rectTransform.DOScale(Vector3.zero, _duaration / 2));
        _sequence.OnComplete(() => { _sequence = null; Destroy(text.gameObject); });
    }
}