using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedMine : MonoBehaviour
{
    public GameObject ExplosionPf;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Physical"))
        {
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(ExplosionPf, this.transform.position, Quaternion.identity);
        Destroy(GetComponentInParent<Mine>().gameObject);
    }
}
