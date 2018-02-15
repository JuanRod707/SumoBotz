using Code.Player;
using UnityEngine;

public class RocketLauncher : PrimaryWeaponBase
{
    public Transform LaunchPosition;
    public PrimaryWeaponStats Stats;
    private GuidedKinematic rocket;

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
        rocket = this.GetComponentInChildren<GuidedKinematic>();
        ResetRocket();
        uiController = GetComponentInParent<BotUIController>();
    }

    void FixedUpdate()
    {
        if (cooldownElapsed > 0)
        {
            cooldownElapsed -= Time.fixedDeltaTime;
            if (cooldownElapsed <= 0)
            {
                ResetRocket();
            }
        }
    }

    public override void Fire()
    {
        if (cooldownElapsed <= 0)
        {
            cooldownElapsed = Stats.Cooldown;
            rocket.Launch();
            uiController.ResetPrimaryCooldown();
        }
    }

    void ResetRocket()
    {
        rocket.gameObject.SetActive(true);
        rocket.transform.SetParent(this.transform);
        rocket.transform.position = LaunchPosition.position;
        rocket.transform.localEulerAngles = Vector3.zero;
    }
}
