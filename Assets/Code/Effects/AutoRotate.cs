using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public Vector3 RotationAxis;
    public float Speed;

    void FixedUpdate()
    {
        this.transform.Rotate(RotationAxis, Speed);
    }
}
