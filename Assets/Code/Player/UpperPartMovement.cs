using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperPartMovement : MonoBehaviour
{
    public Transform AimPoint;

    public void Move()
    {
        Turn();
    }

    void Turn()
    {
        this.transform.LookAt(AimPoint);
    }
}
