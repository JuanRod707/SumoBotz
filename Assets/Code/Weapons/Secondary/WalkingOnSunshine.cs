using UnityEngine;

public class WalkingOnSunshine : SecondaryWeaponBase
{
    public ParticleSystem[] Effects;
    public SecondaryWeaponStats Stats;

    private AudioSource sfx;
    private Rigidbody botBody;

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
        base.Initialize();
        botBody = GetComponentInParent<Rigidbody>();
    }

    protected override void ResetEffect()
    {
        botBody.useGravity = true;
        foreach (var e in Effects)
        {
            e.Stop();    
        }
        
        base.ResetEffect();
    }

    protected override void ApplyEffect()
    {
        botBody.useGravity = false;
        foreach (var e in Effects)
        {
            e.Play();
        }

        effectElapsed = Stats.EffectDuration;
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
