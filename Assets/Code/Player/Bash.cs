using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Bash : MonoBehaviour
{
    public float MinVelocity;
    public float HitFactor;
    public float InputDisableDuration;

    private Rigidbody myBody;

    void Start()
    {
        myBody = this.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Player") || collision.collider.tag.Equals("Physical"))
        {
            if (Mathf.Abs(myBody.velocity.magnitude) > MinVelocity)
            {
                var enemyBody = collision.collider.GetComponentInParent<Rigidbody>();
                var enemyInput = collision.collider.GetComponentInParent<PlayerInput>();

                enemyInput.DisableInputFor(InputDisableDuration);
                enemyBody.AddForce(this.transform.forward * Mathf.Abs(myBody.velocity.magnitude) * HitFactor);
            }
        }
    }
}
