namespace  Code.Player
{
    using Assets.Code.UI;
    using UnityEngine;

    public class BotUIController : MonoBehaviour
    {
        public GameObject PlayerHudPf;
        public string HudContainer;

        private PlayerHud playerHud;
        private BotData botStats;
        private PrimaryWeaponStats primaryStats;
        private SecondaryWeaponStats secondaryStats;

        public void Initialize(BotData data, PrimaryWeaponStats primary, SecondaryWeaponStats secondary)
        {
            botStats = data;
            primaryStats = primary;
            secondaryStats = secondary;

            var hud = Instantiate(PlayerHudPf, GameObject.Find(HudContainer).transform);
            playerHud = hud.GetComponent<PlayerHud>();
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

