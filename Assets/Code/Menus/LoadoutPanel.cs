using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadoutPanel :MonoBehaviour
{
    public Toggle PlayerInGame;
    public Dropdown PlayerCountry;
    public Dropdown PrimaryWeapon;
    public Dropdown SecondaryWeapon;
    public LoadoutSlot AttachedSlot;

    public Loadout GetLoadout()
    {
        if (PlayerInGame.isOn)
        {
            var ldt = new Loadout();
            ldt.Country = (Nationality) PlayerCountry.value;
            ldt.PrimaryWeapon = (PrimaryWeaponType) PrimaryWeapon.value;
            ldt.SecondaryWeapon = (SecondaryWeaponType) SecondaryWeapon.value;

            return ldt;
        }

        return null;
    }

    public void ValueChanged()
    {
        AttachedSlot.SetLoadout(PlayerCountry.value, PrimaryWeapon.value, SecondaryWeapon.value);
    }
}
