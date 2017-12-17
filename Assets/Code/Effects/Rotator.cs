using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float Acceleration;
    public float Deceleration;
    public float MaxSpeed;
    public bool IsAutomatic;

    private float currentSpeed;
    
    void FixedUpdate()
    {
        if (IsAutomatic)
        {
            StartRotating();
        }
        else if(currentSpeed > 0)
        {
            currentSpeed -= Deceleration;
        }

        Rotate();
    }

    void Rotate()
    {
        this.transform.Rotate(0f, 0f, currentSpeed);
    }

    public void StartRotating()
    {
        if (currentSpeed < MaxSpeed)
        {
            currentSpeed += Acceleration;
        }
    }
}
