using UnityEngine;

public class Emp : SecondaryWeaponBase
{
    public EmpStats Stats;
    public GameObject EmpPrefab;

    private int playerId;

    void Start()
    {
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
        }
    }
}
