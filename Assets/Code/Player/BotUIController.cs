using System.Linq;

namespace  Code.Player
{
    using Assets.Code.UI;
    using UnityEngine;

    public class BotUIController : MonoBehaviour
    {
        public string HudContainer;
        public GameObject FloatingHudPf;

        private PlayerHud playerHud;
        private FloatingHud floatHud;
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

            floatHud = Instantiate(FloatingHudPf, Vector3.zero, Quaternion.identity).GetComponent<FloatingHud>();

            var secondaryDeplete = 1 / secondaryStats.EffectDuration * Time.deltaTime;
            floatHud.Initialize(primaryStats.AmmoCap, secondaryDeplete, playerId);
            floatHud.GetComponent<AnchorHud>().SetAnchor(this.transform);
        }

        public void UpdateHp(int currentHp)
        {
            var hpRatio = (float) currentHp / botStats.MaxHealth;
            playerHud.UpdateHp(hpRatio);
        }

        public void ResetDashCooldown()
        {
            playerHud.ResetDashCooldown(botStats.DashCooldown);
            floatHud.ResetDashCooldown(botStats.DashCooldown);
        }

        public void ResetPrimaryCooldown()
        {
            playerHud.ResetPrimaryCooldown(primaryStats.ReloadTime);
            floatHud.ResetPrimaryCooldown(primaryStats.ReloadTime);
        }

        public void ResetSecondaryCooldown()
        {
            playerHud.ResetSecondaryCooldown(secondaryStats.Cooldown);
            floatHud.ResetSecondaryCooldown(secondaryStats.Cooldown);
        }

        public void DepletePrimary(int amount)
        {
            floatHud.DepletePrimary(amount);
        }

        public void DepleteSecondary()
        {
            floatHud.DepleteSecondary();
        }

        public void EmptySecondary()
        {
            floatHud.EmptySecondary();
        }
    }

}

