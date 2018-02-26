using Assets.Code.Game;

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
        public GameObject ExplosionPf;
        public SpriteRenderer PlayerRing;
        [HideInInspector] public WeaponSystem Weapons;

        private GameDirector director;
        private BotUIController uiController;
        private int currentHp;

		private EffectManager effect;

        public bool IsAlive {
            get { return currentHp > 0; }
        }

        public void Initialize(GameObject primary, GameObject melee, GameObject secondary)
        {
            LowerController.LoadStats(Stats);
            currentHp = Stats.MaxHealth;

            Weapons = this.GetComponentInChildren<WeaponSystem>();
            Weapons.LoadPrimary(primary);
            Weapons.LoadSecondary(secondary);
            Weapons.LoadMelee(melee);

            var res = GameObject.Find("PlayerLoader").GetComponent<PlayerResources>();
            var face = res.GetFace(Country);
            uiController = GetComponent<BotUIController>();
            uiController.Initialize(Stats, primary.GetComponent<PrimaryWeaponBase>().GetStats , secondary.GetComponent<SecondaryWeaponBase>().GetStats, PlayerId, face);

            uiController.UpdateHp(currentHp);

            director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
            director.AddPlayer(this);

            PlayerRing.color = res.GetColor(PlayerId);

			effect = this.GetComponent<EffectManager>();
        }
        
        public void ReceiveDamage(int damage)
        {
            currentHp -= damage;
            uiController.UpdateHp(currentHp);
			effect.TriggerDamageEffect();

            if (currentHp <= 0)
            {
                currentHp = 0;
                Instantiate(ExplosionPf, transform.position, Quaternion.identity);
                director.OnPlayerKilled(this);
                gameObject.SetActive(false);
                uiController.PlayerKilled();
            }
        }
    }
}
