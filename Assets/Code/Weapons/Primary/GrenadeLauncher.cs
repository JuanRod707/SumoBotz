using UnityEngine;

public class GrenadeLauncher : PrimaryWeaponBase
{
    public Transform ShootingPosition;
    public ParticleSystem Muzzle;
    public GrenadeLauncherStats GLStats;
    public GameObject Grenade;
    
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
        var dir = this.transform.forward;
        dir.y += GLStats.Arc;

        var range = Random.Range(GLStats.MinRange, GLStats.MaxRange);

        var grenade = Instantiate(Grenade, ShootingPosition.position, Quaternion.identity).GetComponent<Grenade>();
        grenade.Launch(dir, range, Stats.Damage);
        Muzzle.Emit(1);
    }
}
