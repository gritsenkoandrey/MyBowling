using DG.Tweening;
using UnityEngine;


namespace Assets.Scripts
{
    public sealed class DoTweenMove : MonoBehaviour
    {
        [SerializeField] private Vector3 _to = Vector3.zero;
        [SerializeField] private DoTweenParams _tweenParams;
        [SerializeField] private Color _color = Color.white;
        private Material _cubeMaterial;
        private Transform _start;

        private void Awake()
        {
            _cubeMaterial = transform.GetComponent<Renderer>().material;
            _start = this.transform;
        }

        private void Start()
        {
            MoveCubeTo();
        }

        private void MoveCubeTo()
        {
            _start.DOMove(_to, _tweenParams.Duration).SetDelay(_tweenParams.Delay).SetLoops(-1, LoopType.Yoyo);
            _cubeMaterial.DOColor(_color, _tweenParams.Duration).SetLoops(-1, LoopType.Yoyo);
        }
    }
}