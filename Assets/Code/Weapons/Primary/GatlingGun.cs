using Code.Interfaces;
using Code.Player;
using UnityEngine;

public class GatlingGun : PrimaryWeaponBase
{
    public Rotator BarrelRotator;
    public ParticleSystem Muzzle;
    public GatlingStats Stats;
    public GameObject ShotHitPf;
    public GameObject ShotLinePf;

    private float fireElapsed;
    private AudioSource GunClip;
    private float rofElapsed;
    private BotUIController uiController;

    public override float PushForce
    {
        get { return Stats.PushForce; }
    }

    public override PrimaryWeaponStats GetStats
    {
        get { return Stats; }
    }

    void Start()
    {
        GunClip = this.GetComponent<AudioSource>();
        uiController = GetComponentInParent<BotUIController>();
    }

    void FixedUpdate()
    {
        if (fireElapsed > 0)
        {
            Shoot();
            rofElapsed -= Time.fixedDeltaTime;
            fireElapsed -= Time.fixedDeltaTime;
        }
        else if (cooldownElapsed > 0)
        {
            cooldownElapsed -= Time.fixedDeltaTime;
        }
    }

    void Shoot()
    {
        if (rofElapsed <= 0)
        {
            Muzzle.Emit(1);
            rofElapsed = Stats.RateOfFire;
            BarrelRotator.StartRotating();
            GunClip.Play();

            RaycastHit hit;
            var dir = this.transform.forward * 10;
            dir.x += Random.Range(-Stats.Inaccuracy, Stats.Inaccuracy);
            dir.y += Random.Range(-Stats.Inaccuracy, Stats.Inaccuracy);
            dir.z += Random.Range(-Stats.Inaccuracy, Stats.Inaccuracy);

            var ray = new Ray(Muzzle.transform.position, dir);
            if (Physics.Raycast(ray, out hit, Stats.Range))
            {
                DisplayGunshot(hit.point);
                Instantiate(ShotHitPf, hit.point, Quaternion.identity);
                DamageTarget(hit);
                Push(hit);
            }
            else
            {
                DisplayGunshot(ray.GetPoint(Stats.Range));
            }

            uiController.ResetPrimaryCooldown();
        }
    }

    public override void Fire()
    {
        if (cooldownElapsed <= 0)
        {
            fireElapsed = Stats.BurstDuration;
            cooldownElapsed = Stats.Cooldown;
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
            body.AddForce(pushVector * Stats.PushForce);
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
