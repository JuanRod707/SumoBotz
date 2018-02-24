using System.Collections;
using Code.Player;
using UnityEngine;

public abstract class PrimaryWeaponBase : MonoBehaviour
{
    public PrimaryWeaponType WeaponType;
    public PrimaryWeaponStats Stats;

    protected BotUIController uiController;

    private bool canFire;
    private bool isReloading;
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
        uiController = GetComponentInParent<BotUIController>();
        canFire = true;
        ammoInClip = Stats.AmmoCap;
        //transform.localScale = Vector3.one;
    }

    public void OnFire()
    {
        if (ammoInClip > 0 && canFire)
        {
            Fire();
            ammoInClip--;
            uiController.DepletePrimary(1);
            StartCoroutine(CycleFire());
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
        if (!isReloading)
        {
            StartCoroutine(StartReload());
        }
    }

    IEnumerator StartReload()
    {
        isReloading = true;
        ammoInClip = 0;
        uiController.ResetPrimaryCooldown();
        yield return new WaitForSeconds(Stats.ReloadTime);
        ammoInClip = Stats.AmmoCap;
        isReloading = false;
    }

    IEnumerator CycleFire()
    {
        canFire = false;
        yield return new WaitForSeconds(Stats.RateOfFire);
        canFire = true;
    }
}
