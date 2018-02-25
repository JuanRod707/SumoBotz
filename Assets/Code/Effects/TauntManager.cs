using Code.Player;
using UnityEngine;

public class TauntManager : MonoBehaviour
{
    private int ownerId;
	private string tauntSelected;

	public GameObject[] Taunts;

	private ParticleSystem parts;
	private float totalDuration;

	public void Trigger(int playerId, string arrowPressed)
    {
        ownerId = playerId;
		tauntSelected = arrowPressed;
		var tauntPosition = new Vector3 (this.transform.position.x, this.transform.position.y + 4, this.transform.position.z);

		switch (tauntSelected) 
		{
		case "up":
			var taunt = Instantiate(Taunts[0], tauntPosition, Quaternion.identity);
			taunt.transform.parent = this.transform;
			parts = taunt.GetComponent<ParticleSystem>();
			totalDuration = parts.duration + parts.startLifetime;
			Destroy(taunt, totalDuration);
			break;

		case "down":
			var taunt1 = Instantiate (Taunts [1], tauntPosition, Quaternion.identity);
			taunt1.transform.parent = this.transform;
			parts = taunt1.GetComponent<ParticleSystem>();
			totalDuration = parts.duration + parts.startLifetime;
			Destroy(taunt1, totalDuration);
			break;

		case "left":
			var taunt2 = Instantiate(Taunts[2], tauntPosition, Quaternion.identity);
			taunt2.transform.parent = this.transform;
			parts = taunt2.GetComponent<ParticleSystem>();
			totalDuration = parts.duration + parts.startLifetime;
			Destroy(taunt2, totalDuration);
			break;

		case "right":
			var taunt3 = Instantiate(Taunts[3], tauntPosition, Quaternion.identity);
			taunt3.transform.parent = this.transform;
			parts = taunt3.GetComponent<ParticleSystem>();
			totalDuration = parts.duration + parts.startLifetime;
			Destroy(taunt3, totalDuration);
			break;
		}
    }
}
