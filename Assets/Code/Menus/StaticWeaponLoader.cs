using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class StaticWeaponLoader : MonoBehaviour
{
    public Transform[] PrimaryWeaponSpots;
    public Transform SecondaryWeaponSpot;
    
    public void LoadPrimary(GameObject weapon)
    {
        foreach (var s in PrimaryWeaponSpots)
        {
            var weap = Instantiate(weapon, s);
            weap.transform.localPosition = Vector3.zero;
        }
    }

    public void LoadSecondary(GameObject weapon)
    {
        var weap = Instantiate(weapon, SecondaryWeaponSpot);
        weap.transform.localPosition = Vector3.zero;
    }
}
