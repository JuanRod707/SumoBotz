using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [HideInInspector] public PrimaryWeaponBase[] PrimaryWeapon;
    [HideInInspector] public SecondaryWeaponBase[] SecondaryWeapon;

    public Transform[] PrimaryWeaponSpots;
    public Transform[] SecondaryWeaponSpots;
    
    public void LoadPrimary(GameObject weapon)
    {
        foreach (var s in PrimaryWeaponSpots)
        {
            var weap = Instantiate(weapon, s);
            weap.transform.localPosition = Vector3.zero;
        }

        PrimaryWeapon = this.GetComponentsInChildren<PrimaryWeaponBase>();
    }

    public void LoadSecondary(GameObject weapon)
    {
        foreach (var s in SecondaryWeaponSpots)
        {
            var weap = Instantiate(weapon, s);
            weap.transform.localPosition = Vector3.zero;
        }

        SecondaryWeapon = this.GetComponentsInChildren<SecondaryWeaponBase>();
    }
}
