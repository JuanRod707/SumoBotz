using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class FloatingHud : MonoBehaviour
    {
        public Image DashBar;
        public Image PrimaryBar;
        public Image SecondaryIcon;
     
        private float primaryRecovery;
        private float primaryUnitValue;
        private float secondaryRecovery;
        private float secondaryDepleteRate;
        private float dashRecovery;

        public void Initialize(int primaryAmmoCap, float secondaryDeplete, int playerId)
        {
            primaryUnitValue = 1f / primaryAmmoCap;
            secondaryDepleteRate = secondaryDeplete;

            SetColors(playerId);
        }

        public void ResetDashCooldown(float cooldown)
        {
            DashBar.fillAmount = 0f;
            dashRecovery = (1/cooldown) * Time.deltaTime;
        }

        public void DepletePrimary(int amount)
        {
            PrimaryBar.fillAmount -= primaryUnitValue * amount;
        }

        public void DepleteSecondary()
        {
            SecondaryIcon.fillAmount -= secondaryDepleteRate;
        }

        public void EmptySecondary()
        {
            SecondaryIcon.fillAmount = 0.01f;
        }

        public void ResetPrimaryCooldown(float cooldown)
        {
            PrimaryBar.fillAmount = 0f;
            primaryRecovery = (1 / cooldown) * Time.deltaTime;
        }

        public void ResetSecondaryCooldown(float cooldown)
        {
            SecondaryIcon.fillAmount = 0f;
            secondaryRecovery = (1 / cooldown) * Time.deltaTime;
        }

        void Update()
        {
            if (DashBar.fillAmount < 1)
            {
                DashBar.fillAmount += dashRecovery;
            }

            if (PrimaryBar.fillAmount < 1)
            {
                PrimaryBar.fillAmount += primaryRecovery;
            }
            else
            {
                primaryRecovery = 0f;
            }

            if (SecondaryIcon.fillAmount < 1)
            {
                SecondaryIcon.fillAmount += secondaryRecovery;
            }
            else
            {
                secondaryRecovery = 0f;
            }
        }

        void SetColors(int playerId)
        {
            var res = GameObject.Find("PlayerLoader").GetComponent<PlayerResources>();
            var children = GetComponentsInChildren<Image>();
            foreach (var c in children)
            {
                c.color = res.PlayerColors[playerId - 1];
            }
        }
    }
}
