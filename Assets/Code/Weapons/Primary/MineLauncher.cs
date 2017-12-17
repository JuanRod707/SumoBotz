using UnityEngine;

public class MineLauncher : PrimaryWeaponBase
{
    public Transform ShootingPosition;
    public ParticleSystem Muzzle;
    public MineLauncherStats Stats;
    public GameObject Mine;
    
    public override float PushForce
    {
        get { return Stats.PushForce; }
    }

    void Start()
    {
    }

    void FixedUpdate()
    {
        if (cooldownElapsed > 0)
        {
            cooldownElapsed -= Time.fixedDeltaTime;
        }
    }

    public override void Fire()
    {
        if (cooldownElapsed <= 0)
        {
            var dir = this.transform.forward;
            dir.x += Random.Range(-Stats.Inaccuracy, Stats.Inaccuracy);
            dir.y += Random.Range(-Stats.Inaccuracy, Stats.Inaccuracy);
            dir.z += Random.Range(-Stats.Inaccuracy, Stats.Inaccuracy);

            var mine = Instantiate(Mine, ShootingPosition.position, Quaternion.identity);
            mine.GetComponent<Rigidbody>().AddForce(dir * Random.Range(Stats.MinRange, Stats.MaxRange));
            Muzzle.Emit(1);

            cooldownElapsed = Stats.Cooldown;
        }
    }
}
