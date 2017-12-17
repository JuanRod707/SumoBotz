using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicCollider : MonoBehaviour
{
    private GuidedKinematic projectile;
    private PrimaryWeaponBase _primaryWeapon;

    void Start()
    {
        projectile = this.GetComponent<GuidedKinematic>();
        _primaryWeapon = this.GetComponentInParent<PrimaryWeaponBase>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (projectile != null && projectile.IsFlying)
        {
            if (collision.rigidbody.tag.Equals("Player") || collision.rigidbody.tag.Equals("Physical"))
            {
                projectile.Explode();
                Push(collision.rigidbody);
            }
        }
    }

    void Push(Rigidbody body)
    {
        var pushVector = this.transform.forward;
        body.AddForce(pushVector * _primaryWeapon.PushForce);
    }
}
