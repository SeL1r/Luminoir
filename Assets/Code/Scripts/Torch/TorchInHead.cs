using System.Collections;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TorchInHead : MonoBehaviour
{
	[SerializeField] private Torch torch;
	[SerializeField] private Light lightTorch;
	[SerializeField] private Image chargeBar;
	private InputAction IAActiveTorch;
	public bool isTorch {get; private set;} = true;
	private bool isPicked = false;
	public float maxChargeValue {get; private set;} = 7;
	private float lossRateCharge = 0.05f;
	private float minChargeValueEvent = 0.3f;
	private int probabilityFlashingLight = 5;
	public float charge = 7;
	

	void Start()
	{
		//InitializationVariables
		IAActiveTorch = InputSystem.actions.FindAction("ActiveTorch");
		
		StartCoroutine(FlashingLight());
	}
	void Update()
	{
		if(torch.isInteract)
		{
			RaiseTorch(); 
		}
		ActiveTorch();
	}
	private void RaiseTorch()
	{
		lightTorch.enabled = true;
		torch.isInteract = false;	
		isPicked = true;
	}
	
	private void ActiveTorch()
	{
		if (!isPicked)
		{
			return;
		}
		if (IAActiveTorch.WasPressedThisFrame())
		{
			if (isTorch)
			{
				lightTorch.enabled = false;
				isTorch = false;
			}
			else
			{
				lightTorch.enabled = true;
				isTorch = true;
			}
		}
		if (isTorch)
		{
			charge = Mathf.MoveTowards(charge, 0, lossRateCharge * Time.deltaTime);
		}
		lightTorch.intensity = charge;
		chargeBar.fillAmount = charge/7;
	}
	
	private IEnumerator FlashingLight()
	{
		while (true)
		{
			yield return new WaitForSecondsRealtime(0.1f);
			
			if (!(chargeBar.fillAmount <= minChargeValueEvent))
			{
				continue;
			}
			int probability = Random.Range(0, 100);
			if(!(probability <= probabilityFlashingLight))
			{
				continue;
			}
			if (!isTorch)
			{
				continue;
			}
			int qualityFlashingLight = Random.Range(1, 4);
			for (int i = 0; i < qualityFlashingLight; i++)
			{
				lightTorch.enabled = false;
				yield return new WaitForSecondsRealtime(0.1f);
				lightTorch.enabled = true;
			}
		}
	}
}
