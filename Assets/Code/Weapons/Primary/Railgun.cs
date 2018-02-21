using Code.Interfaces;
using UnityEngine;

public class Railgun : PrimaryWeaponBase
{
    public ParticleSystem Muzzle;
    public RailgunStats RGStats;
    public GameObject ShotHitPf;
    public GameObject ShotLinePf;

    public override float PushForce
    {
        get { return Stats.PushForce; }
    }

    public override PrimaryWeaponStats GetStats
    {
        get { return Stats; }
    }

    public override void Fire()
    {
        Muzzle.Emit(1);

        RaycastHit hit;
        var dir = this.transform.forward;

        var ray = new Ray(Muzzle.transform.position, dir);
        if (Physics.Raycast(ray, out hit, RGStats.Range))
        {
            DisplayGunshot(hit.point);
            Instantiate(ShotHitPf, hit.point, Quaternion.identity);
            DamageTarget(hit);
            Push(hit);
        }
        else
        {
            DisplayGunshot(ray.GetPoint(RGStats.Range));
        }
    }

    void DisplayGunshot(Vector3 pos2)
    {
        var line = Instantiate(ShotLinePf, Muzzle.transform.position, Quaternion.identity).GetComponent<LineRenderer>();
        line.SetPosition(0, Muzzle.transform.position);
        line.SetPosition(1, pos2);
    }

    void Push(RaycastHit hit)
    {
        if (hit.collider.tag.Equals("Physical"))
        {
            var body = hit.collider.GetComponentInParent<Rigidbody>();
            var pushVector = this.transform.forward;
            if (body != null)
            {
                body.AddForce(pushVector * Stats.PushForce);
            }
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
