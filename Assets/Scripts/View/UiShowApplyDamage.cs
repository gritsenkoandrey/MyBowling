using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public sealed class UiShowApplyDamage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text = null;
    [SerializeField] private BuildingParams _tweenParams = null;
    [SerializeField] private Transform _canvas = null;

    public void ApplyDamage(Vector3 position, int point)
    {
        ScoreController.CountScore += point;

        var pos = new Vector3(position.x + Random.Range(-1.0f, 1.0f), position.y + Random.Range(1, 5.0f), position.z);
        var text = Instantiate(_text, pos, Quaternion.identity, _canvas);

        text.text = $"{Mathf.Round(point)}";
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f);

        var rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        Sequence sequence = DOTween.Sequence();

        var posY = rectTransform.anchoredPosition.y + 0.0f;
        sequence.Append(rectTransform.DOAnchorPosY(posY, _tweenParams.Duration));
        sequence.Insert(0.0f, rectTransform.DOScale(Vector3.one, _tweenParams.Duration));
        sequence.Insert(0.0f, text.DOFade(1.0f, _tweenParams.Duration / 2.0f));
        sequence.Append(rectTransform.DOScale(Vector3.zero, _tweenParams.Duration / 2));
        sequence.OnComplete(() => { sequence = null; Destroy(text.gameObject); });
    }
}