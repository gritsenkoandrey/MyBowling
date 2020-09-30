using UnityEngine;
using DG.Tweening;
using TMPro;


namespace Assets.Scripts.DoTween
{
    public sealed class DoTweenShowText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private DoTweenParams _tweenParams;
        private Transform _canvas;

        private void Awake()
        {
            _canvas = FindObjectOfType<Canvas>().transform;
        }

        public void ApplyDamage(Vector3 position, float point)
        {
            var pos = new Vector3(position.x + Random.Range(-1.0f, 1.0f), position.y + Random.Range(0, 1.5f));

            var text = Instantiate(_text, pos, Quaternion.identity, _canvas);

            text.text = $"{Mathf.Round(point)}";
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f);

            var rectTransform = text.GetComponent<RectTransform>();
            rectTransform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            Sequence sequence = DOTween.Sequence();

            var posY = rectTransform.anchoredPosition.y + 10.0f;
            sequence.Append(rectTransform.DOAnchorPosY(posY, _tweenParams.Duration));
            sequence.Insert(0.0f, rectTransform.DOScale(Vector3.one, _tweenParams.Duration));
            sequence.Insert(0.0f, text.DOFade(1.0f, _tweenParams.Duration / 2.0f));
            sequence.Append(rectTransform.DOScale(Vector3.zero, _tweenParams.Duration / 2));
            sequence.OnComplete(() => { sequence = null; Destroy(text.gameObject); });
        }
    }
}