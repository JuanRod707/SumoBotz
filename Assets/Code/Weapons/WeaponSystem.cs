using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [HideInInspector] public PrimaryWeaponBase PrimaryWeapon;
    [HideInInspector] public SecondaryWeaponBase SecondaryWeapon;

    public Transform PrimaryWeaponSpot;
    public Transform MeleeWeaponSpot;
    public Transform SecondaryWeaponSpot;

    public void LoadPrimary(GameObject weapon)
    {
        var weap = Instantiate(weapon, PrimaryWeaponSpot);
        weap.transform.localPosition = Vector3.zero;
        PrimaryWeapon = weap.GetComponent<PrimaryWeaponBase>();
    }

    public void LoadSecondary(GameObject weapon)
    {
        var weap = Instantiate(weapon, SecondaryWeaponSpot);
        weap.transform.localPosition = Vector3.zero;
        SecondaryWeapon = weap.GetComponent<SecondaryWeaponBase>();
    }
}
