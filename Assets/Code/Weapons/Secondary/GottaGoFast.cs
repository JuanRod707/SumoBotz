using Code.Player;
using UnityEngine;

public class GottaGoFast : SecondaryWeaponBase
{
    public ParticleSystem[] Effects;
    public SpeedStats Stats;

    private AudioSource sfx;
    private BotData stats;
    private float baseTopSpeed;
    private float baseSpeed;

    public override SecondaryWeaponStats GetStats
    {
        get { return Stats; }
    }

    void FixedUpdate()
    {
        if (isActive)
        {
            effectElapsed -= Time.fixedDeltaTime;
            if (effectElapsed <= 0f)
            {
                ResetEffect();
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
        sfx = this.GetComponent<AudioSource>();
        Initialize();
    }

    protected override void Initialize()
    {
        stats = GetComponentInParent<PlayerBot>().Stats;
        baseSpeed = stats.SpeedScore;
        baseTopSpeed = stats.TopSpeed;
    }

    protected override void ResetEffect()
    {
        stats.TopSpeed = baseTopSpeed;
        stats.SpeedScore = baseSpeed;
        foreach (var e in Effects)
        {
            e.Stop();
        }

        base.ResetEffect();
    }

    protected override void ApplyEffect()
    {
        stats.TopSpeed *= Stats.SpeedMultiplier;
        stats.SpeedScore *= Stats.SpeedMultiplier;
        effectElapsed = Stats.EffectDuration;
        foreach (var e in Effects)
        {
            e.Play();
        }

        base.ApplyEffect();
    }

    public override void Fire()
    {
        if (cooldownElapsed <= 0)
        { 
            ApplyEffect();
            sfx.Play();
            cooldownElapsed = Stats.Cooldown;
        }
    }
}
