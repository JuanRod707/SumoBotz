using System.Collections;
using Code.Player;
using UnityEngine;

public abstract class PrimaryWeaponBase : MonoBehaviour
{
    public PrimaryWeaponType WeaponType;
    public PrimaryWeaponStats Stats;

    protected BotUIController uiController;

    private bool canFire;
    private int ammoInClip;

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
        ammoInClip = Stats.AmmoCap;
    }

    public void OnFire()
    {
        if (ammoInClip > 0 && canFire)
        {
            Fire();
            StartCoroutine(CycleFire());
            ammoInClip--;
        }
        else if(ammoInClip <= 0)
        {
            Reload();
        }
    }

    public virtual void Fire()
    {

    }

    private void Reload()
    {
        StartCoroutine(StartReload());
    }

    IEnumerator StartReload()
    {
        ammoInClip = 0;
        yield return new WaitForSeconds(Stats.ReloadTime);
        ammoInClip = Stats.AmmoCap;
    }

    IEnumerator CycleFire()
    {
        canFire = false;
        yield return new WaitForSeconds(Stats.RateOfFire);
        canFire = true;
    }
}
