using Code.Interfaces;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject ExplosionPf;
    public float Lifetime;
    public float RotationFactor;

    private int damage;

    public void Launch(Vector3 direction, float launchForce, int damage)
    {
        this.damage = damage;
        var body = GetComponent<Rigidbody>();
        body.AddForce(direction * launchForce);
        body.AddTorque(Random.insideUnitSphere * RotationFactor);
    }

    void Update()
    {
        Lifetime -= Time.deltaTime;
        if (Lifetime <= 0)
        {
            Explode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damageable = collision.other.GetComponent<IDamageable>();
        if (damageable == null)
        {
            damageable = collision.other.GetComponentInParent<IDamageable>();
        }

        if (damageable != null)
        {
            damageable.ReceiveDamage(damage);
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(ExplosionPf, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
