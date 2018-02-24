using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class StaticWeaponLoader : MonoBehaviour
{
    public Transform PrimaryWeaponSpots;
    public Transform MeleeWeaponSlot;
    public Transform SecondaryWeaponSpot;

    public void LoadPrimary(GameObject weapon)
    {
        var weap = Instantiate(weapon, PrimaryWeaponSpots);
        weap.transform.localPosition = Vector3.zero;
    }

    public void LoadMelee(GameObject weapon)
    {
        var weap = Instantiate(weapon, MeleeWeaponSlot);
        weap.transform.localPosition = Vector3.zero;
    }

    public void LoadSecondary(GameObject weapon)
    {
        var weap = Instantiate(weapon, SecondaryWeaponSpot);
        weap.transform.localPosition = Vector3.zero;
    }
}
