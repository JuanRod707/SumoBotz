using System.Linq;

namespace  Code.Player
{
    using Assets.Code.UI;
    using UnityEngine;

    public class BotUIController : MonoBehaviour
    {
        public string HudContainer;

        private PlayerHud playerHud;
        private BotData botStats;
        private PrimaryWeaponStats primaryStats;
        private SecondaryWeaponStats secondaryStats;

        public void Initialize(BotData data, PrimaryWeaponStats primary, SecondaryWeaponStats secondary, int playerId, Sprite face)
        {
            botStats = data;
            primaryStats = primary;
            secondaryStats = secondary;

            var huds = GameObject.Find("PlayerStats").GetComponent<PlayerHudManager>();
            playerHud = huds.GetPlayerHud(playerId);
            playerHud.LoadFace(face);
        }

        public void UpdateHp(int currentHp)
        {
            var hpRatio = (float) currentHp / botStats.MaxHealth;
            playerHud.UpdateHp(hpRatio);
        }

        public void ResetDashCooldown()
        {
            playerHud.ResetDashCooldown(botStats.DashCooldown);
        }

        public void ResetPrimaryCooldown()
        {
            playerHud.ResetPrimaryCooldown(primaryStats.Cooldown);
        }

        public void ResetSecondaryCooldown()
        {
            playerHud.ResetSecondaryCooldown(secondaryStats.Cooldown);
        }
    }

}

