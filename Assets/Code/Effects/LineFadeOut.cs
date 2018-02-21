using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFadeOut : MonoBehaviour
{
    public float LifeSpan;

    private LineRenderer line;
    private float initialLife;

    void Start()
    {
        initialLife = LifeSpan;
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        LifeSpan -= Time.deltaTime;
        var col = line.startColor;
        col.a -= Time.deltaTime * initialLife;

        line.startColor = col;
        line.endColor = col;

        if (LifeSpan < 0)
        {
            Destroy(this.gameObject);
        }
    }
}