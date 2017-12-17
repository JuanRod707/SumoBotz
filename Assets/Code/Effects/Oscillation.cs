using UnityEngine;

public class Oscillation : MonoBehaviour
{
    public float OscillatorFactor;
    public float InitialOffset;

    public float OscillatorFrequency;
    private float angle = 0f;
    private float originalY;

	// Use this for initialization
	void Start ()
	{
	    originalY = this.transform.localPosition.z;
	    this.transform.localPosition = new Vector3(0f,0f, InitialOffset);

    }
	
	// Update is called once per frame
	void Update ()
	{
	    var oscillation = OscillatorFactor * Mathf.Sin(angle);
	    var newPos = transform.localPosition;
        newPos.z = originalY + oscillation;
	    this.transform.localPosition = newPos;

	    this.angle += OscillatorFrequency;
	}
}
