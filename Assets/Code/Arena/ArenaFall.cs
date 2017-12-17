using System;
using UnityEngine;

public class ArenaFall : MonoBehaviour
{
    public Transform[] SpawnPoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Physical"))
        {
            other.GetComponentInParent<PlayerBot>().transform.position = SpawnPoints.PickOne().position;
        }
    }
}