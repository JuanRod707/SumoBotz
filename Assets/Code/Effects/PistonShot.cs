using UnityEngine;

public class PistonShot : MonoBehaviour
{
    public float ThrustDistance;
    public float ReturnSpeed;

    private Vector3 originalPos;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, originalPos, ReturnSpeed);
    }

    public void Thrust()
    {
        transform.Translate(Vector3.forward * ThrustDistance);
    }
}
