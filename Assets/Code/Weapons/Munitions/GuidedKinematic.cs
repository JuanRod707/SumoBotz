using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedKinematic : MonoBehaviour
{
    public float Lifespan;
    public float Acceleration;

    public float TurnStrength;
    public float IdleTime;
    public float MaxSpeed;

    public GameObject Explosion;
    
    private ParticleSystem[] effects;
    private float currentLifespan;
    private Transform target;
    private bool readyToTurn;
    private float travelSpeed;
    private bool isFlying;
    private Rigidbody myBody;

    public bool IsFlying {
        get { return isFlying; }
    }

    void Start()
    {
        effects = this.GetComponentsInChildren<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        if (isFlying)
        {
            currentLifespan -= Time.deltaTime;

            if (!readyToTurn)
            {
                IdleTime -= Time.fixedDeltaTime;
                if (IdleTime <= 0)
                {
                    readyToTurn = true;
                }
            }
            else if (target != null)
            {
                var targetToLocal = this.transform.InverseTransformPoint(target.transform.position);
                if (targetToLocal.x > 0)
                {
                    Turn(TurnStrength);
                }
                else
                {
                    Turn(-TurnStrength);
                }
            }

            if (travelSpeed < MaxSpeed)
            {
                travelSpeed += Acceleration;
            }

            this.transform.Translate(Vector3.forward * travelSpeed);

            if (currentLifespan <= 0)
            {
                Explode();
            }
        }
    }

    void Turn(float turnFactor)
    {
        this.transform.Rotate(this.transform.up, turnFactor);
    }

    public void Explode()
    {
        Instantiate(Explosion, this.transform.position, Quaternion.identity);
        isFlying = false;
        this.travelSpeed = 0f;
        this.target = null;
        this.readyToTurn = false;

        foreach (var e in effects)
        {
            e.Stop();
        }

        this.gameObject.SetActive(false);
    }

    public void Launch()
    {
        this.transform.SetParent(null);
        currentLifespan = Lifespan;
        isFlying = true;
        this.GetComponent<AudioSource>().Play();

        foreach (var e in effects)
        {
            e.Play();
        }
    }

    public void LockOn(Transform target)
    {
        if (readyToTurn && this.target == null)
        {
            this.target = target;
        }
    }
}
