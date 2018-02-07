using System;
using System.Linq;
using Code.Player;
using UnityEngine;

public class PlayerLoader :MonoBehaviour
{
    public Loadout[] DefaultLoadouts;
    public Transform[] SpawnPoints;

    private PlayerResources resources;

    void Start()
    {
        resources = this.GetComponent<PlayerResources>();
        Load();
    }

    public void Load()
    {
        if (GameState.Loadouts != null && GameState.Loadouts.Any())
        {
            LoadStatic();
        }
        else
        {
            LoadDefault();
        }
    }

    void LoadDefault()
    {
        int playerIndex = 0;
        foreach (var ldt in DefaultLoadouts)
        {
            var bot = Instantiate(resources.GetBot(ldt.Country), SpawnPoints[playerIndex].position, Quaternion.identity).GetComponent<PlayerBot>();
            bot.Initialize(resources.GetPrimary(ldt.PrimaryWeapon), resources.GetSecondary(ldt.SecondaryWeapon));
            bot.PlayerId = playerIndex + 1;

            playerIndex++;
        }
    }

    void LoadStatic()
    {
        int playerIndex = 0;
        foreach (var ldt in GameState.Loadouts)
        {
            if (ldt != null)
            {
                var bot = Instantiate(resources.GetBot(ldt.Country), SpawnPoints[playerIndex].position,
                    Quaternion.identity).GetComponent<PlayerBot>();
                bot.Initialize(resources.GetPrimary(ldt.PrimaryWeapon), resources.GetSecondary(ldt.SecondaryWeapon));
                bot.PlayerId = playerIndex + 1;
            }

            playerIndex++;
        }
    }
}
