using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedDetector : MonoBehaviour
{
    private GuidedKinematic projectile;

    void Start()
    {
        projectile = this.GetComponentInParent<GuidedKinematic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (projectile != null && projectile.IsFlying)
        {
            if (other.tag.Equals("Player") || other.tag.Equals("Physical"))
            {
                projectile.LockOn(other.gameObject.transform);
            }
        }
    }
}
