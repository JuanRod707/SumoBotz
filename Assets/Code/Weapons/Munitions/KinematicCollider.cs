using Code.Interfaces;
using UnityEngine;

public class KinematicCollider : MonoBehaviour
{
    private GuidedKinematic projectile;
    private int damage;
    private float pushForce;

    public void LoadStats(float pushforce, int damage)
    {
        this.damage = damage;
        this.pushForce = pushforce;
        projectile = this.GetComponent<GuidedKinematic>();
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
                body.AddForce(pushVector * pushForce);
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
            dmgBody.ReceiveDamage(damage);
        }
    }
}
