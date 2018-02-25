using Code.Player;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
	public GameObject[] TauntEffects;
	public GameObject[] DamageEffects;
	public GameObject DashEffect;

	private ParticleSystem parts;
	private float totalDuration;

	private GameObject currentTaunt;

	public void TriggerTaunt(int arrowPressed)
    {		
		if (currentTaunt == null) 
		{
			var tauntPosition = new Vector3 (this.transform.position.x, this.transform.position.y + 4, this.transform.position.z);
			currentTaunt = Instantiate (TauntEffects [arrowPressed], tauntPosition, Quaternion.identity);
			currentTaunt .transform.parent = this.transform;
			parts = currentTaunt .GetComponent<ParticleSystem> ();
			totalDuration = parts.duration + parts.startLifetime;
			Destroy (currentTaunt, totalDuration);
		}
	}

	public void TriggerDamageEffect()
	{
		var damage = Instantiate (DamageEffects.PickOne(), this.transform.position, Quaternion.identity);
		parts = damage.GetComponent<ParticleSystem> ();
		totalDuration = parts.duration + parts.startLifetime;
		Destroy (damage, totalDuration);
	}

	public void TriggerDashEffect()
	{
		var dash = Instantiate (DashEffect, this.transform.position, Quaternion.identity);
		parts = dash.GetComponent<ParticleSystem> ();
		totalDuration = parts.duration + parts.startLifetime;
		Destroy (dash, totalDuration);
	}
}