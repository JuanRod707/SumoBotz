using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDispose : MonoBehaviour
{
    public float LifeSpan;

    void Update()
    {
        LifeSpan -= Time.deltaTime;

        if (LifeSpan < 0)
        {
            Destroy(this.gameObject);
        }
    }
}