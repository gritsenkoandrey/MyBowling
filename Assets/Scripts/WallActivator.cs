using UnityEngine;
using DG.Tweening;


namespace Assets.Scripts
{
    public sealed class WallActivator : MonoBehaviour
    {
        public void MoveWall(Vector3 pos, float move, Ease ease)
        {
            DOTween.Sequence().Append(transform.DOMove(pos, move).SetEase(ease));
        }
    }
}