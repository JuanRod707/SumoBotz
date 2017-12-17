using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseLight : MonoBehaviour
{
    public float PulseFrequency;
    private float pulseElapsed;
    private Light myLight;

    void Start()
    {
        pulseElapsed = PulseFrequency;
        myLight = this.GetComponent<Light>();
    }

    void Update()
    {
        pulseElapsed -= Time.deltaTime;
        if (pulseElapsed <= 0)
        {
            pulseElapsed = PulseFrequency;
            myLight.enabled = !myLight.enabled;
        }
    }
}