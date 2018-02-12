using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicLabel : MonoBehaviour
{
    public string Format;

    [HideInInspector]
    public Text myText;

    // Use this for initialization
    void Start()
    {
        myText = this.GetComponent<Text>();
    }

    public void SetLabel(params object[] values)
    {
        if (myText == null)
        {
            myText = this.GetComponent<Text>();
        }

        myText.text = string.Format(Format, values);
    }
}