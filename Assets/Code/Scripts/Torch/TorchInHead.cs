using System.Collections;
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
			charge = Mathf.MoveTowards(charge, 0, 0.05f * Time.deltaTime);
		}
		lightTorch.intensity = charge;
		chargeBar.fillAmount = charge/7;
	}
	
	private IEnumerator FlashingLight()
	{
		while (true)
		{
			yield return new WaitForSecondsRealtime(0.1f);
			
			if (!(chargeBar.fillAmount <= 0.3f))
			{
				continue;
			}
			if(!(Random.Range(0, 100) <= 5))
			{
				continue;
			}
			if (!isTorch)
			{
				continue;
			}
			
			for (int i = 0; i < Random.Range(1, 4); i++)
			{
				lightTorch.enabled = false;
				yield return new WaitForSecondsRealtime(0.1f);
				lightTorch.enabled = true;
			}
		}
	}
}
