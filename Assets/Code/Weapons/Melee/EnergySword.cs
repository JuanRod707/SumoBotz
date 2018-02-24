using Assets.Code.Weapons.Melee;
using UnityEngine;

public class EnergySword : MeleeWeaponBase
{
    public GameObject MeleeAoE;
    
    public override float PushForce
    {
        get { return Stats.PushForce; }
    }

    public override void Hit()
    {
        GetComponentInChildren<PistonShot>().Thrust();
        var hit = Instantiate(MeleeAoE, FirePosition.position, transform.rotation).GetComponent<MeleeAttack>();
        hit.Attack(Stats.Damage, PushForce);
    }
}
