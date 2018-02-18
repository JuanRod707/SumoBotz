using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GatlingStats
{
    public float Accuracy;
    public float Range;

    public float Inaccuracy
    {
        get { return (100f - Accuracy) / 10f; }
    }
}
