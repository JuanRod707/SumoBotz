using System.Collections;
using System.Collections.Generic;
using System.Net;
using Code.Player;
using UnityEngine;

public abstract class PrimaryWeaponBase : MonoBehaviour
{
    public PrimaryWeaponType WeaponType;
    
    protected float cooldownElapsed;
    protected BotUIController uiController;

    public virtual float PushForce {
        get { return 0f; }
    }

    public virtual PrimaryWeaponStats GetStats {
        get { return null; }
    }

    public virtual void Fire()
    {
        
    }
}
