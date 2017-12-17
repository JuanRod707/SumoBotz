using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour
{
    public void Rotate(float angle)
    {
        this.transform.Rotate(angle, 0f, 0f);
    }
}
