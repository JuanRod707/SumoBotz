using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public abstract class SecondaryWeaponBase : MonoBehaviour
{
    public SecondaryWeaponType WeaponType;

    protected float cooldownElapsed;
    protected float effectElapsed;
    protected bool isActive;

    protected virtual void Initialize()
    {
    }

    protected virtual void ResetEffect()
    {
        isActive = false;
    }

    protected virtual void ApplyEffect()
    {
        isActive = true;
    }

    public virtual void Fire()
    {
        
    }
}
