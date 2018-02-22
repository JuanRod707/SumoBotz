using UnityEngine;

public class ShieldEffect : MonoBehaviour
{
    private Transform anchor;

    public void Attach(Transform anchor)
    {
        this.anchor = anchor;
    }

    public void TurnOff()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        this.transform.position = anchor.position;
        this.transform.rotation = anchor.rotation;
    }
}
