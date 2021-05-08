using Scripts;
using UnityEngine;


public sealed class Ball : BallBase
{
    public override void Launch(Vector3 direction)
    {
        if (IsLaunch == false && IsBallAlive == true)
        {
            gun.FireOn();
            gun.FireParticleON();
            Services.Instance.AudioService.PlaySound(AudioName.CANNON_SHOT);
            myBody.useGravity = true;
            myBody.AddForce(Quaternion.LookRotation(direction) * speedBall, ForceMode.VelocityChange);
            IsLaunch = true;
            timeRemainingDestroyBall.AddTimeRemaining();
        }
    }
}