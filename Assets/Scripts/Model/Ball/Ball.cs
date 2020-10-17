using ExampleTemplate;
using UnityEngine;


public sealed class Ball : BallBase, ILaunch
{
    public void Launch(Vector2 direction)
    {
        if (IsLaunch == false)
        {
            rigidbodyBase.useGravity = true;
            rigidbodyBase.AddForce(Quaternion.LookRotation
                (new Vector3(direction.x, 0, direction.y)) * _speedBall, ForceMode.VelocityChange);
            IsLaunch = true;

            _timeRemaining.AddTimeRemaining();
        }
    }
}