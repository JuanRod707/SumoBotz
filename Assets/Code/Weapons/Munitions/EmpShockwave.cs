using UnityEngine;

public class EmpShockwave : MonoBehaviour
{
    private int ownerId;
    private float stunDuration;

    public void Trigger(int playerId, float stunDuration, float range)
    {
        ownerId = playerId;
        this.stunDuration = stunDuration;
        var col = this.gameObject.AddComponent<SphereCollider>();
        col.radius = range;
        col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Physical"))
        {
            var target = other.GetComponentInParent<PlayerBot>();
            if (target.PlayerId != ownerId)
            {
                target.GetComponent<PlayerInput>().DisableInputFor(stunDuration);
            }
        }
    }
}
