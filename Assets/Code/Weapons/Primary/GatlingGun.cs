using Code.Interfaces;
using Code.Player;
using UnityEngine;

public class GatlingGun : PrimaryWeaponBase
{
    public Rotator BarrelRotator;
    public ParticleSystem Muzzle;
    public GatlingStats GGStats;
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
        BarrelRotator.StartRotating();

        RaycastHit hit;
        var dir = this.transform.forward * 10;
        dir.x += Random.Range(-GGStats.Inaccuracy, GGStats.Inaccuracy);
        dir.y += Random.Range(-GGStats.Inaccuracy, GGStats.Inaccuracy);
        dir.z += Random.Range(-GGStats.Inaccuracy, GGStats.Inaccuracy);

        var ray = new Ray(Muzzle.transform.position, dir);
        if (Physics.Raycast(ray, out hit, GGStats.Range))
        {
            DisplayGunshot(hit.point);
            Instantiate(ShotHitPf, hit.point, Quaternion.identity);
            DamageTarget(hit);
            Push(hit);
        }
        else
        {
            DisplayGunshot(ray.GetPoint(GGStats.Range));
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
