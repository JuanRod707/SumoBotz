using System.Collections;
using Code.Player;
using UnityEngine;

public abstract class MeleeWeaponBase : MonoBehaviour
{
    public MeleeWeaponType WeaponType;
    public Transform FirePosition;
    public MeleeWeaponStats Stats;
    
    protected BotUIController uiController;

    private bool canFire;

    public virtual float PushForce
    {
        get { return 0f; }
    }

    public virtual PrimaryWeaponStats GetStats
    {
        get { return null; }
    }

    protected void Start()
    {
        canFire = true;
    }

    public void OnFire()
    {
        if (canFire)
        {
            Hit();
            StartCoroutine(CycleFire());
        }
    }

    public virtual void Hit()
    {

    }

    IEnumerator CycleFire()
    {
        canFire = false;
        yield return new WaitForSeconds(Stats.RateOfFire);
        canFire = true;
    }
}
