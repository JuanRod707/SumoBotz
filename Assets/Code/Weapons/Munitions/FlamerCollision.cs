using Code.Interfaces;
using UnityEngine;

public class FlamerCollision : MonoBehaviour
{
    private int damage;

    public void SetStats(int dmg)
    {
        damage = dmg;
    }

    private void OnParticleCollision(GameObject other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable == null)
        {
            damageable = other.GetComponentInParent<IDamageable>();
        }

        if (damageable != null)
        {
            damageable.ReceiveDamage(damage);
        }
    }
}
