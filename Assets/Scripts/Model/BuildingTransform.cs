using UnityEngine;
using DG.Tweening;


public sealed class BuildingTransform : MonoBehaviour
{
    [SerializeField] private Vector3 _to = Vector3.zero;
    [SerializeField] private BuildingParams _buildingParams = null;
    [SerializeField] private BuildingMoveType _buildingMoveType = BuildingMoveType.No;

    private void Start()
    {
        if (_buildingMoveType == BuildingMoveType.Move)
        {
            MoveObject();
        }

        if (_buildingMoveType == BuildingMoveType.Rotate)
        {
            RotateObject();
        }
    }

    private void MoveObject()
    {
        transform
            .DOMove(_to, _buildingParams.Duration)
            .SetEase(_buildingParams.Ease)
            .SetDelay(_buildingParams.Delay)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void RotateObject()
    {
        transform
            .DORotate(_to, _buildingParams.Duration)
            .SetEase(_buildingParams.Ease)
            .SetDelay(_buildingParams.Delay)
            .SetLoops(-1, LoopType.Yoyo);
    }
}