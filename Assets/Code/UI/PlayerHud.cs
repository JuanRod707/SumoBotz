﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    class PlayerHud : MonoBehaviour
    {
        public Image[] Lives;
        public Image HpBar;
        public Image DashBar;
        public Image PrimaryIcon;
        public Image SecondaryIcon;
        public Image UltimateIcon;

        private float primaryRecovery;
        private float secondaryRecovery;
        private float dashRecovery;


        public void UpdateHp(float hp)
        {
            HpBar.fillAmount = hp;
        }

        public void ResetDashCooldown(float cooldown)
        {
            DashBar.fillAmount = 0f;
            dashRecovery = (1/cooldown) * Time.deltaTime;
        }

        public void ResetPrimaryCooldown(float cooldown)
        {
            PrimaryIcon.fillAmount = 0f;
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

            if (PrimaryIcon.fillAmount < 1)
            {
                PrimaryIcon.fillAmount += primaryRecovery;
            }

            if (SecondaryIcon.fillAmount < 1)
            {
                SecondaryIcon.fillAmount += secondaryRecovery;
            }
        }
    }
}