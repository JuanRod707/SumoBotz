using Code.Player;
using UnityEngine;

public class TauntManager : MonoBehaviour
{
    private int ownerId;
	private int tauntSelected;

	public GameObject[] Taunts;

	private ParticleSystem parts;
	private float totalDuration;

	public void Trigger(int playerId, int arrowPressed)
    {
        ownerId = playerId;
		tauntSelected = arrowPressed;
		var tauntPosition = new Vector3 (this.transform.position.x, this.transform.position.y + 4, this.transform.position.z);

		var taunt = Instantiate (Taunts[tauntSelected], tauntPosition, Quaternion.identity);
		taunt.transform.parent = this.transform;
		parts = taunt.GetComponent<ParticleSystem>();
		totalDuration = parts.duration + parts.startLifetime;
		Destroy(taunt, totalDuration);
    }
}