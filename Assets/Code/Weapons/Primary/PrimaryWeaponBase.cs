using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public abstract class PrimaryWeaponBase : MonoBehaviour
{
    public PrimaryWeaponType WeaponType;
    
    protected float cooldownElapsed;
    public virtual float PushForce {
        get { return 0f; }
    }

    public virtual void Fire()
    {
        
    }
}
