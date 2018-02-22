using System.Linq;
using Code.Interfaces;
using UnityEngine;

public class Flamer : PrimaryWeaponBase
{
    public ParticleSystem[] flames;

    private FlamerCollision collider;

    public override PrimaryWeaponStats GetStats
    {
        get { return Stats; }
    }

    public override void Fire()
    {
        ReloadFlames();
        foreach (var f in flames)
        {
            f.Emit(1);
        }
    }

    void ReloadFlames()
    {
        if (flames == null || !flames.Any())
        {
            flames = GetComponentsInChildren<ParticleSystem>();
            collider = GetComponentInChildren<FlamerCollision>();
            collider.SetStats(Stats.Damage);
        }
    }

    void DamageTarget(RaycastHit hit)
    {
        var dmgBody = hit.collider.GetComponent<IDamageable>();

        if (dmgBody == null)
        {
            dmgBody = hit.collider.GetComponentInParent<IDamageable>();
        }

        if(dmgBody != null)
        {
            dmgBody.ReceiveDamage(Stats.Damage);
        }
    }
}
