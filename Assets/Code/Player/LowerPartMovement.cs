﻿using System.Collections;
using System.Collections.Generic;
using Code.Player;
using UnityEngine;

public class LowerPartMovement : MonoBehaviour
{
    public Transform AimPoint;

    protected BotData botStats;
    protected bool dashIsCoolingDown;
    protected float dashElapsed;
    protected float dashCooldownElapsed;
    protected Rigidbody myBody;

	private EffectManager effect;

    protected void Start()
    {
        myBody = this.GetComponent<Rigidbody>();
		effect = this.GetComponent<EffectManager>();
    }

    protected virtual void FixedUpdate()
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

				if (dashElapsed < 0)
                {
                    dashIsCoolingDown = true;
                    dashCooldownElapsed = botStats.DashCooldown;
                }
            }
            else
            {
                {
                    if (myBody.velocity.magnitude > botStats.TopSpeed)
                    {
                        myBody.AddForce(-myBody.velocity.normalized * 900);
                    }
                }
            }
        }
    }

    public virtual void Move()
    {
        if (myBody != null)
        {
            myBody.AddForce(this.transform.forward * botStats.SpeedScore);
            Turn();
        }
    }

    public void DashForward()
    {
        if (!dashIsCoolingDown)
        {
//---------------------------------------------------------------------------Bruno
			effect.TriggerDashEffect();
//---------------------------------------------------------------------------
	
            dashElapsed = botStats.DashDuration;
            dashIsCoolingDown = true;
            dashCooldownElapsed = botStats.DashCooldown;
            GetComponentInParent<BotUIController>().ResetDashCooldown();
        }
    }

    protected void Turn()
    {
        this.transform.LookAt(AimPoint);
    }

    public void LoadStats(BotData stats)
    {
        this.botStats = stats;
    }
}
