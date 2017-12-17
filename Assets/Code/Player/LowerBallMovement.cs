using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerBallMovement : LowerPartMovement
{
    public BallRotation Ball;
    public float BallRotation;

    public override void Move()
    {
        myBody.AddForce(this.transform.forward * botStats.SpeedScore);
        Turn();
        Ball.Rotate(BallRotation);
    }

    protected override void FixedUpdate()
    {
        if (myBody != null && botStats != null)
        {
            if (dashIsCoolingDown)
            {
                dashCooldownElapsed -= Time.fixedDeltaTime;
                if (dashCooldownElapsed < 0)
                {
                    dashIsCoolingDown = false;
                }
            }
            if (dashElapsed > 0)
            {
                dashElapsed -= Time.fixedDeltaTime;
                myBody.AddForce(this.transform.forward * botStats.DashForce);
                Ball.Rotate(BallRotation * 5);
                if (dashElapsed < 0)
                {
                    dashIsCoolingDown = true;
                    dashCooldownElapsed = botStats.DashCooldown;
                }
            }
            else
            {

                if (myBody.velocity.magnitude > botStats.TopSpeed)
                {
                    myBody.AddForce(-myBody.velocity.normalized * 900);
                }
            }
        }
    }
}
