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

    public override float PushForce
    {
        get { return Stats.PushForce; }
    }

    void Start()
    {
        GunClip = this.GetComponent<AudioSource>();
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
                Push(hit);
            }
            else
            {
                DisplayGunshot(ray.GetPoint(Stats.Range));
            }
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
}
