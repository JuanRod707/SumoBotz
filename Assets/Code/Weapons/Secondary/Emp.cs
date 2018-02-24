using Code.Player;
using UnityEngine;

public class Emp : SecondaryWeaponBase
{
    public EmpStats Stats;
    public GameObject EmpPrefab;

    private int playerId;

    public override SecondaryWeaponStats GetStats
    {
        get { return Stats; }
    }

    void Start()
    {
        Initialize();
        playerId = this.GetComponentInParent<PlayerBot>().PlayerId;
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
        if(cooldownElapsed <= 0)
        {
            var shock = Instantiate(EmpPrefab, this.transform.position, Quaternion.identity).GetComponent<EmpShockwave>();
            shock.Trigger(playerId, Stats.EffectDuration, Stats.ShockwaveRange);
            cooldownElapsed = Stats.Cooldown;
            uiController.ResetSecondaryCooldown();
        }
    }
}
