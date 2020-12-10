using System;
using UnityEngine;


namespace Scripts
{
    [Serializable]
    public struct ShakeInfo
    {
        public float Duration;
        public float Strength;
        public int Vibrato;

        [Range(0.0f, 90.0f)]
        public float Randomness;

        public Vector3 StartCameraTransform;
    }
}
