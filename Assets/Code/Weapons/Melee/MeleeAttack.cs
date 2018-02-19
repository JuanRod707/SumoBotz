using System.Collections.Generic;
using Code.Interfaces;
using UnityEngine;

namespace Assets.Code.Weapons.Melee
{
    public class MeleeAttack : MonoBehaviour
    {
        private int damage;
        private List<IDamageable> damagedEntities;

        private List<IDamageable> dmgList {
            get
            {
                if (damagedEntities == null)
                {
                    damagedEntities = new List<IDamageable>();
                }

                return damagedEntities;
            }
        }

        public void Attack(int dmg)
        {
            damage = dmg;
        }

        private void OnTriggerEnter(Collider other)
        {
            var target = other.GetComponent<IDamageable>();

            if (target == null)
            {
                target = other.GetComponentInParent<IDamageable>();
            }

            if (target != null && !dmgList.Contains(target))
            {
                dmgList.Add(target);
                target.ReceiveDamage(damage);
            }
        }
    }
}
