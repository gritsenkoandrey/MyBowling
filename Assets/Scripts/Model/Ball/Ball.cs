using Scripts;
using UnityEngine;


public sealed class Ball : BallBase
{
    public override void Launch(Vector2 direction)
    {
        if (isLaunch == false && isBallAlive == true)
        {
            gun.FireOn();
            gun.FireParticleON();
            myBody.useGravity = true;
            myBody.AddForce(Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y)) * speedBall,
                ForceMode.VelocityChange);
            isLaunch = true;

            timeRemainingDestroyBall.AddTimeRemaining();
        }
    }
}