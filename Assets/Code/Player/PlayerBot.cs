using System.Linq;

namespace Code.Player
{
    using Code.Interfaces;
    using UnityEngine;

    public class PlayerBot : MonoBehaviour, IDamageable
    {
        public Nationality Country;
        public BotData Stats;
        public int PlayerId;
        public LowerPartMovement LowerController;
        public UpperPartMovement UpperController;
        [HideInInspector] public WeaponSystem Weapons;

        private BotUIController uiController;
        private int currentHp;

        public void Initialize(GameObject primary, GameObject secondary)
        {
            LowerController.LoadStats(Stats);
            currentHp = Stats.MaxHealth;

            Weapons = this.GetComponentInChildren<WeaponSystem>();
            Weapons.LoadPrimary(primary);
            Weapons.LoadSecondary(secondary);

            uiController = GetComponent<BotUIController>();
            uiController.Initialize(Stats, primary.GetComponent<PrimaryWeaponBase>().GetStats , secondary.GetComponent<SecondaryWeaponBase>().GetStats);

            uiController.UpdateHp(currentHp);
        }
        
        public void ReceiveDamage(int damage)
        {
            currentHp -= damage;
            uiController.UpdateHp(currentHp);

            if (currentHp <= 0)
            {
                currentHp = 0;
                //EXPLODE
            }
        }
    }
}
