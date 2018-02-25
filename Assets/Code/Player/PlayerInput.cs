using Code.Player;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Transform LowerAimPoint;
    public Transform UpperAimPoint;
    public UpperPartMovement UpperMover;
    public float DeadZone;
    public float SeparationFactor;

    private LowerPartMovement lowerMover;
    private PlayerBot bot;
	private EffectManager taunt;

	private string VArrow;
	private string HArrow;

	private bool DPadVPressed = false;
	private bool DPadHPressed = false;

    private string LowerHorizontal;
    private string LowerVertical;
    private string UpperHorizontal;
    private string UpperVertical;
    private string PrimaryFire;
    private string SecondaryFire;
    private string Triggers;

    private float inputDisableElapsed;
    private bool inputIsDisabled;

    // Use this for initialization
    void Start ()
    {
        lowerMover = this.GetComponent<LowerPartMovement>();
        bot = this.GetComponent<PlayerBot>();
		taunt = this.GetComponent<EffectManager>();

		VArrow = "VArrow_P" + bot.PlayerId;
		HArrow = "HArrow_P" + bot.PlayerId;

        LowerHorizontal = "LowerH_P" + bot.PlayerId;
        LowerVertical = "LowerV_P" + bot.PlayerId;
        UpperHorizontal = "UpperH_P" + bot.PlayerId;
        UpperVertical = "UpperV_P" + bot.PlayerId;
        PrimaryFire = "PFire_P" + bot.PlayerId;
        SecondaryFire = "SFire_P" + bot.PlayerId;
        Triggers = "Triggers_P" + bot.PlayerId;
    }
	
	// Update is called once per frame
    void FixedUpdate()
    {
        if (!inputIsDisabled)
        {
            var lAxis = new Vector2(Input.GetAxis(LowerHorizontal), Input.GetAxis(LowerVertical));
            if (lAxis.magnitude > DeadZone)
            {
                LowerAimPoint.position = this.transform.position + new Vector3(lAxis.x, 0f, lAxis.y) * SeparationFactor;
                lowerMover.Move();
            }

            var uAxis = new Vector2(Input.GetAxis(UpperHorizontal), Input.GetAxis(UpperVertical));
            if (uAxis.magnitude > DeadZone)
            {
                UpperAimPoint.position = UpperMover.transform.position + new Vector3(uAxis.x, 0f, uAxis.y) * SeparationFactor;
                UpperMover.Move();
            }

            if (Input.GetButton(PrimaryFire))
            {
                bot.Weapons.PrimaryWeapon.OnFire();
            }

            if (Input.GetButtonDown(SecondaryFire))
            {
                bot.Weapons.SecondaryWeapon.Fire();
            }

            var tAxis = Input.GetAxis(Triggers);

            if (tAxis <= -0.9f)
            {
                lowerMover.DashForward();
            }

            if (tAxis >= 0.9f)
            {
                bot.Weapons.MeleeWeapon.OnFire();
            }
//------------------------------------------------------ Codigo Bruno
			var dPadV = Input.GetAxisRaw(VArrow);

			if(dPadV == 1 && !DPadVPressed)
			{
				taunt.TriggerTaunt (0);
				DPadVPressed = true;
			}
								
			if(dPadV == -1 && !DPadVPressed)
			{				
				taunt.TriggerTaunt (1);
				DPadVPressed = true;
			}
				
			if(dPadV == 0)
			{
				DPadVPressed = false;
			}

			var dPadH = Input.GetAxisRaw(HArrow);

			if(dPadH == 1 && !DPadHPressed)
			{
				taunt.TriggerTaunt (2);
				DPadHPressed = true;
			}

			if(dPadH == -1 && !DPadHPressed)
			{
				taunt.TriggerTaunt (3);
				DPadHPressed = true;
			}

			if(dPadH == 0)
			{
				DPadHPressed = false;
			}
//--------------------------------------------------------
        }
        else
        {
            inputDisableElapsed -= Time.fixedDeltaTime;
            if (inputDisableElapsed < 0)
            {
                inputIsDisabled = false;
            }
        }
    }

    public void DisableInputFor(float duration)
    {
        inputDisableElapsed = duration;
        inputIsDisabled = true;
    }
}
