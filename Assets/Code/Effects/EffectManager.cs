using Code.Player;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
	public GameObject[] TauntEffects;
	public GameObject[] DamageEffects;
	public GameObject DashEffect;
    public GameObject[] EmpDebuffs;
    public GameObject ConfettiEffect;

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

    public void TriggerEmpDebuff()
    {
        var debuffPostion = new Vector3(this.transform.position.x, this.transform.position.y + 4, this.transform.position.z);
        var debuff = Instantiate(EmpDebuffs[0], debuffPostion, Quaternion.identity);
        debuff.transform.parent = this.transform;
        parts = debuff.GetComponent<ParticleSystem>();
        totalDuration = parts.duration + parts.startLifetime;
        Destroy(debuff, totalDuration);
    }

    public void TriggerConfetti()
    {
        var confettiPosition = new Vector3(this.transform.position.x, this.transform.position.y + 4, this.transform.position.z);
        var confetti = Instantiate(ConfettiEffect, confettiPosition, Quaternion.identity);
        parts = confetti.GetComponent<ParticleSystem>();
        totalDuration = parts.duration + parts.startLifetime;
        Destroy(confetti, totalDuration);
    }
}