using Code.Player;
using UnityEngine;

public class RocketLauncher : PrimaryWeaponBase
{
    public Transform LaunchPosition;
    public GameObject RocketPf;

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
        var rocket = Instantiate(RocketPf, LaunchPosition.position, transform.rotation).GetComponent<GuidedKinematic>();
        rocket.Launch();
        rocket.GetComponent<KinematicCollider>().LoadStats(Stats.PushForce, Stats.Damage);
    }
}
