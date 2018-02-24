using System.Collections;
using System.Collections.Generic;
using System.Net;
using Code.Player;
using UnityEngine;

public abstract class SecondaryWeaponBase : MonoBehaviour
{
    public SecondaryWeaponType WeaponType;

    protected float cooldownElapsed;
    protected float effectElapsed;
    protected bool isActive;
    protected BotUIController uiController;

    public virtual SecondaryWeaponStats GetStats
    {
        get { return null; }
    }

    protected virtual void Initialize()
    {
        uiController = GetComponentInParent<BotUIController>();
    }

    protected virtual void ResetEffect()
    {
        isActive = false;
        uiController.ResetSecondaryCooldown();
    }

    protected virtual void ApplyEffect()
    {
        isActive = true;
    }

    public virtual void Fire()
    {
        
    }
}
