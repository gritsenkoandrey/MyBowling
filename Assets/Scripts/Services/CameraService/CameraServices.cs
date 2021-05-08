using DG.Tweening;
using UnityEngine;


namespace Scripts
{
    public sealed class CameraServices : Service
    {
        private readonly Sequence _sequence;
        private ShakeInfo _shakeInfo;

        #region ClassLifeCycles

        public CameraServices()
        {
            SetCamera(Camera.main);
            _sequence = DOTween.Sequence();
        }

        #endregion
        
        
        #region Properties

        public Camera CameraMain { get; private set; }

        #endregion


        #region Methods


        public void CreateShake(ShakeType shakeType)
        {
            _shakeInfo = Data.Instance.Shakes.GetShakeInfo(shakeType);

            _sequence.Insert(0.0f, CameraMain.transform.DOMove(_shakeInfo.StartCameraTransform, 0.0f));
            _sequence.Append(CameraMain.DOShakePosition(_shakeInfo.Duration, _shakeInfo.Strength, _shakeInfo.Vibrato, _shakeInfo.Randomness));
        }

        // public void MoveToPosition(Vector3 position, float moveDuration,
        //     Ease ease = Ease.OutSine)
        // {
        //     if (CameraMain.transform.hasTweener)
        //     {
        //         CameraMain.transform.tweener.value.Kill();
        //         CameraMain.transform.RemoveTweener();
        //     }
        //
        //     Tweener tweener = DOTween.To(() => CameraMain.transform.position, CameraMain.transform.position,
        //         position, moveDuration).SetEase(ease).OnComplete(CameraMain.transform.RemoveTweener);
        // }


        public void SetCamera(Camera camera)
        {
            CameraMain = camera;
        }

        #endregion
    }
}
