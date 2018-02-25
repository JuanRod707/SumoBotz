using System.Collections;
using UnityEngine;
using UnityEngine.Collections;

public class AberratePosition : MonoBehaviour
{
    public float EffectDuration;
    public float EffectMultiplier;
    public float EffectFrequency;

    public Vector3 zeroPos;
    private float effectElapsed;
    private float cycleElapsed;
    private bool isOn;

    void Start()
    {
        zeroPos = transform.localPosition;
    }

    void Update()
    {
        if (effectElapsed > 0)
        {
            if (cycleElapsed > 0)
            {
                Aberrate();
                cycleElapsed -= Time.deltaTime;
            }
            else
            {
                cycleElapsed = EffectFrequency;
            }

            effectElapsed -= Time.deltaTime;
            if (effectElapsed <= 0)
            {
                transform.localPosition = zeroPos;
            }
        }
    }

    public void StartEffect()
    {
        effectElapsed = EffectDuration;
        cycleElapsed = EffectFrequency;
        isOn = true;
    }

    void Aberrate()
    {
        var aberrateVector = Random.insideUnitSphere * EffectMultiplier;
        aberrateVector.z = 0;

        transform.localPosition = zeroPos + aberrateVector;
    }
}
