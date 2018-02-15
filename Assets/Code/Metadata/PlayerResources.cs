using System;
using System.Linq;
using Assets.Code.Metadata;
using Code.Player;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public GameObject[] BotsPfs;
    public GameObject[] PrimariesPfs;
    public GameObject[] SecondariesPfs;
    public CountryFacePair[] Faces;

    public Sprite GetFace(Nationality country)
    {
        return Faces.First(x => x.Country == country).FaceSprite;
    }

    public GameObject GetBot(Nationality country)
    {
        return BotsPfs.FirstOrDefault(x => x.GetComponent<PlayerBot>().Country == country);
    }

    public GameObject GetPrimary(PrimaryWeaponType wpType)
    {
        return PrimariesPfs.FirstOrDefault(x => x.GetComponent<PrimaryWeaponBase>().WeaponType == wpType);
    }

    public GameObject GetSecondary(SecondaryWeaponType wpType)
    {
        return SecondariesPfs.FirstOrDefault(x => x.GetComponent<SecondaryWeaponBase>().WeaponType == wpType);
    }
}
