using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GrenadeLauncherStats
{
    public float Accuracy;
    public float MinRange;
    public float MaxRange;

    public float Inaccuracy
    {
        get { return (100f - Accuracy) / 10f; }
    }
}
