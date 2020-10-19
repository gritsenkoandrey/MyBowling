using Scripts;
using UnityEngine;


public sealed class Ball : BallBase
{
    public override void Launch(Vector2 direction)
    {
        if (IsLaunch == false)
        {
            rigidbodyBase.useGravity = true;
            rigidbodyBase.AddForce(Quaternion.LookRotation
                (new Vector3(direction.x, 0, direction.y)) * speedBall, ForceMode.VelocityChange);
            IsLaunch = true;

            timeRemainingDestroyBall.AddTimeRemaining();
        }
    }
}