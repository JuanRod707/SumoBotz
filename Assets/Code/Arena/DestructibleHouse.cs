using System;
using System.Linq;
using Code.Interfaces;
using Code.Player;
using UnityEngine;

public class DestructibleHouse : MonoBehaviour, IDamageable
{
    public int InitialHp;
    public GameObject[] States;
    public ParticleSystem SmokeBlast;
    public ParticleSystem Fire;

    private int[] stateValues;
    private int currentHp;
    private int currentStateIndex;
    private GameObject currentState;

    void Start()
    {
        currentHp = InitialHp;
        currentState = States.Last();
        CalculateStateThresholds();
    }

    void CalculateStateThresholds()
    {
        stateValues = new int[States.Length];
        var singleStateValue = InitialHp / (States.Length - 1);

        stateValues[0] = 0;
        stateValues[States.Length - 1] = InitialHp;

        for (int i = 1; i < States.Length - 1; i++)
        {
            stateValues[i] = stateValues[i - 1] + singleStateValue;
        }
    }

    void UpdateState()
    {
        for (int i = stateValues.Length-1; i >= 0 ; i--)
        {
            if (currentHp <= stateValues[i])
            {
                currentStateIndex = i;
            }
        }

        if (currentState != States[currentStateIndex])
        {
            ChangeState();
        }
    }

    void ChangeState()
    {
        currentState = States[currentStateIndex];
        foreach (var s in States)
        {
            s.SetActive(false);
        }

        currentState.SetActive(true);
        SmokeBlast.Play();
        Fire.Play();

        if (currentState == States.First())
        {
            Fire.Stop();
            this.GetComponent<Collider>().enabled = false;
        }
    }

    public void ReceiveDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp < 0)
        {
            currentHp = 0;
        }
        UpdateState();
    }
}