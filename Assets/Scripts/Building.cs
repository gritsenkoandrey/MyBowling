using UnityEngine;
using DG.Tweening;
using System.Collections;


namespace Assets.Scripts
{
    public enum DoTweenType
    {
        None,
        MovementOneWay,
        MovementTwoWay,
        MovementTwoWayLooping,
        MovementTwoWayWithSequence,
        MovementOneWayColorChange,
        MovementOneWayColorChangeAndScale,
        RotationTwoWay,
        MovementToPath
    }

    public sealed class Building : MonoBehaviour
    {
        [SerializeField] private Vector3 _targetPos = Vector3.zero;
        [SerializeField] private Vector3[] _targetPath;
        private Vector3 _currentPos;
        private Vector3 _originalPos;

        [SerializeField] private DoTweenType _doTweenType = DoTweenType.MovementOneWay;
        [SerializeField] private Ease _ease;
        [SerializeField] private Color _targetColor;

        [Range(1.0f, 10.0f), SerializeField] private float _colorChangeDuration = 1.0f;
        [Range(0.5f, 10.0f), SerializeField] private float _moveDuration = 1.0f;
        [Range(1.0f, 100.0f), SerializeField] private float _targetScale = 1.0f;

        private void Start()
        {
            if (_doTweenType == DoTweenType.MovementOneWay)
            {
                if (_targetPos == Vector3.zero)
                {
                    _targetPos = transform.position;
                }
                transform.DOMove(_targetPos, _moveDuration).SetEase(_ease);
            }
            else if (_doTweenType == DoTweenType.MovementTwoWay)
            {
                if (_targetPos == Vector3.zero)
                {
                    _targetPos = transform.position;
                }
                StartCoroutine(MoveWithBothWays());
            }
            else if (_doTweenType == DoTweenType.MovementTwoWayLooping)
            {
                if (_targetPos == Vector3.zero)
                {
                    _targetPos = transform.position;
                }
                _originalPos = transform.position;
                _currentPos = _targetPos;
                LoopMovement(_currentPos);
            }
            else if (_doTweenType == DoTweenType.MovementTwoWayWithSequence)
            {
                if (_targetPos == Vector3.zero)
                {
                    _targetPos = transform.position;
                }
                _originalPos = transform.position;
                DOTween.Sequence()
                        .Append(transform.DOMove(_targetPos, _moveDuration).SetEase(_ease))
                        .Append(transform.DOMove(_originalPos, _moveDuration).SetEase(_ease))
                        .CompletedLoops();
            }
            else if (_doTweenType == DoTweenType.MovementOneWayColorChange)
            {
                if (_targetPos == Vector3.zero)
                {
                    _targetPos = transform.position;
                }
                DOTween.Sequence()
                    .Append(transform.DOMove(_targetPos, _moveDuration).SetEase(_ease))
                    .Append(transform.GetComponent<Renderer>().material
                    .DOColor(_targetColor, _colorChangeDuration).SetEase(_ease));
            }
            else if (_doTweenType == DoTweenType.MovementOneWayColorChangeAndScale)
            {
                if (_targetPos == Vector3.zero)
                {
                    _targetPos = transform.position;
                }
                DOTween.Sequence()
                    .Append(transform.DOMove(_targetPos, _moveDuration).SetEase(_ease))
                    .Append(transform.DOScale(_targetScale, _moveDuration / 2.0f).SetEase(_ease))
                    .Append(transform.GetComponent<Renderer>().material
                    .DOColor(_targetColor, _colorChangeDuration).SetEase(_ease));
            }
            else if (_doTweenType == DoTweenType.RotationTwoWay)
            {
                if (_targetPos == Vector3.zero)
                {
                    _targetPos = transform.position;
                }
                _originalPos = transform.rotation.eulerAngles;
                _currentPos = _targetPos;
                LoopRotation(_currentPos);
            }
            else if (_doTweenType == DoTweenType.MovementToPath)
            {
                if (_targetPos == Vector3.zero)
                {
                    _targetPos = transform.position;
                }
                DOTween.Sequence()
                    .Append(transform.DOPath(_targetPath, _moveDuration).SetEase(_ease));
            }
        }

        private IEnumerator MoveWithBothWays()
        {
            _originalPos = transform.position;
            transform.DOMove(_targetPos, _moveDuration).SetEase(_ease);
            yield return new WaitForSeconds(_moveDuration);
            transform.DOMove(_originalPos, _moveDuration).SetEase(_ease);
        }

        private void LoopMovement(Vector3 pos)
        {
            transform.DOMove(pos, _moveDuration).SetEase(_ease)
                .OnComplete(() => LoopMovement(_currentPos)).SetDelay(_moveDuration);
            _currentPos = _currentPos == _targetPos ? _originalPos : _targetPos;
        }

        private void LoopRotation(Vector3 angle)
        {
            transform.DORotate(angle, _moveDuration).SetEase(_ease)
                .OnComplete(() => LoopRotation(_currentPos)).SetDelay(_moveDuration);
            _currentPos = _currentPos == _targetPos ? _originalPos : _targetPos;
        }
    }
}