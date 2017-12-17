using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class LoadoutSlot : MonoBehaviour
{
    public MeshRenderer Flag;
    public Material[] FlagMaterials;
    public Transform BotPlatform;
    public PlayerResources Resources;

    void Start()
    {
        SetLoadout(0,0,0);
    }

    public void SetLoadout(int country, int primary, int secondary)
    {
        if (BotPlatform.childCount > 0)
        {
            Destroy(BotPlatform.GetComponentInChildren<StaticWeaponLoader>().gameObject);
        }

        var bot = Instantiate(Resources.BotsPfs[country], BotPlatform).GetComponent<StaticWeaponLoader>();
        bot.LoadPrimary(Resources.PrimariesPfs[primary]);
        bot.LoadSecondary(Resources.SecondariesPfs[secondary]);

        Flag.material = FlagMaterials[country];
    }
}
