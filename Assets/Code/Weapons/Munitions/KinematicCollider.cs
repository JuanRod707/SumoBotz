using Code.Interfaces;
using UnityEngine;

public class KinematicCollider : MonoBehaviour
{
    private GuidedKinematic projectile;
    private PrimaryWeaponBase primaryWeapon;

    void Start()
    {
        projectile = this.GetComponent<GuidedKinematic>();
        primaryWeapon = this.GetComponentInParent<PrimaryWeaponBase>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (projectile != null && projectile.IsFlying)
        {
            Push(collision.rigidbody);
            DamageTarget(collision.rigidbody);
            projectile.Explode();
        }
    }

    void Push(Rigidbody body)
    {
        if (body.tag.Equals("Physical"))
        {
            var pushVector = this.transform.forward;
            if (body != null)
            {
                body.AddForce(pushVector * primaryWeapon.PushForce);
            }
        }
    }

    void DamageTarget(Rigidbody body)
    {
        var dmgBody = body.GetComponent<IDamageable>();

        if (dmgBody == null)
        {
            dmgBody = body.GetComponentInParent<IDamageable>();
        }

        if (dmgBody != null)
        {
            dmgBody.ReceiveDamage(primaryWeapon.GetStats.Damage);
        }
    }
}
