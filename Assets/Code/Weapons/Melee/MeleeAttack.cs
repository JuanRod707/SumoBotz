using System.Collections.Generic;
using Code.Interfaces;
using UnityEngine;

namespace Assets.Code.Weapons.Melee
{
    public class MeleeAttack : MonoBehaviour
    {
        private int damage;
        private List<IDamageable> damagedEntities;
        private float pushForce;

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

        public void Attack(int dmg, float pushForce)
        {
            damage = dmg;
            this.pushForce = pushForce;
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
                Push(other);
            }
        }

        void Push(Collider col)
        {
            var body = col.GetComponent<Rigidbody>();

            if (body == null)
            {
                body = col.GetComponentInParent<Rigidbody>();
            }

            if (body != null)
            {
                var distance = Vector3.Lerp(this.transform.position, body.transform.position, 1f).normalized;
                var pushvector = transform.InverseTransformVector(distance);
                pushvector.y = 0f;

                body.AddForce(pushvector * pushForce);
            }
        }
    }
}
