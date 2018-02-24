using UnityEngine;

public class Shield : SecondaryWeaponBase
{
    public GameObject ShieldEffect;
    public SecondaryWeaponStats Stats;

    private ShieldEffect effect;

    public override SecondaryWeaponStats GetStats
    {
        get { return Stats; }
    }

    void FixedUpdate()
    {
        if (isActive)
        {
            effectElapsed -= Time.fixedDeltaTime;
            uiController.DepleteSecondary();
            if (effectElapsed <= 0f)
            {
                ResetEffect();
                effect.TurnOff();
            }
        }
        else
        {
            if (cooldownElapsed > 0)
            {
                cooldownElapsed -= Time.fixedDeltaTime;
            }
        }
    }

    void Start()
    {
        Initialize();
    }

    protected override void ApplyEffect()
    {
        effectElapsed = Stats.EffectDuration;
        base.ApplyEffect();

        effect = Instantiate(ShieldEffect, transform.position, transform.rotation).GetComponent<ShieldEffect>();
        effect.Attach(this.transform);
    }

    public override void Fire()
    {
        if (cooldownElapsed <= 0)
        {
            ApplyEffect();
            cooldownElapsed = Stats.Cooldown;
        }
    }
}
