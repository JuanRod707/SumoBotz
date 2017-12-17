using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject ArmedState;

    private bool isArmed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.CompareTag("Scenery") && !isArmed)
        {
            isArmed = true;
            ArmedState.SetActive(true);
        }
    }
}
