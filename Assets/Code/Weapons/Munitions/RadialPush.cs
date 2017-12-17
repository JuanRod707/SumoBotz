using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialPush : MonoBehaviour
{
    public float PushStrength;
    public float DistanceFactor;
    public float Lockdown;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Physical"))
        {
            var enemyBody = other.GetComponentInParent<Rigidbody>();
            var enemyInput = enemyBody.GetComponent<PlayerInput>();

            enemyInput.DisableInputFor(Lockdown);
            var vectorPush = this.transform.InverseTransformPoint(enemyBody.transform.position);
            var distance = Vector3.Distance(this.transform.position, enemyBody.transform.position) * DistanceFactor;

            enemyBody.AddForce(vectorPush * PushStrength);
        }
    }
}
