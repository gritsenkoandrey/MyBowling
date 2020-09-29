using System.Linq;
using UnityEngine;
using DG.Tweening;


namespace Assets.Scripts.DoTween
{
    public sealed class DoTweenPaths : MonoBehaviour
    {
        [SerializeField] private PathType _pathtype = PathType.CatmullRom;
        [SerializeField] private DoTweenParams _tweenParams;
        [SerializeField] private Vector3[] _waypoints;

        private void Start()
        {
            transform.DOPath(_waypoints, _tweenParams.Duration, _pathtype, PathMode.Full3D)
                .SetOptions(true, AxisConstraint.None, AxisConstraint.X | AxisConstraint.Z)
                .SetDelay(_tweenParams.Delay)
                .SetEase(_tweenParams.Ease)
                .SetLoops(-1);
        }
    }
    #region DoTweenPaths_v.2
    //public sealed class DoTweenPaths : MonoBehaviour
    //{
    //    [SerializeField] private Transform _target;
    //    [SerializeField] private Transform _targetLookAt;
    //    [SerializeField] private PathType _pathtype = PathType.CatmullRom;
    //    [SerializeField] private DoTweenParams _tweenParams;
    //    [SerializeField] private Vector3[] _waypoints;

    //    private void OnValidate()
    //    {
    //        var nodes = GetComponentsInChildren<Transform>().ToList();
    //        nodes.Remove(transform);
    //        _waypoints = nodes.Select(t => t.position).ToArray();
    //    }

    //    private void Start()
    //    {
    //        _target.DOPath(_waypoints, _tweenParams.Duration, _pathtype, PathMode.Full3D)
    //            .SetOptions(true, AxisConstraint.None, AxisConstraint.X | AxisConstraint.Z)
    //            .SetLookAt(_targetLookAt.position)
    //            .SetEase(_tweenParams.Ease)
    //            .SetDelay(_tweenParams.Delay)
    //            .SetLoops(-1);
    //    }
    //}
    #endregion
}