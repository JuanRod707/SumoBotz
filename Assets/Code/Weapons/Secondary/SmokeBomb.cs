using UnityEngine;

public class SmokeBomb : SecondaryWeaponBase
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
        botBody = GetComponentInParent<Rigidbody>();
    }

    protected override void ResetEffect()
    {
        botBody.detectCollisions = true;
        botBody.useGravity = true;
        foreach (var e in Effects)
        {
            e.Stop();
        }

        base.ResetEffect();
    }

    protected override void ApplyEffect()
    {
        botBody.detectCollisions = false;
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
