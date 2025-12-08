using UnityEngine;
using UnityEngine.UI;

public class TorchInHead : MonoBehaviour
{
	[SerializeField] private Torch torch;
	[SerializeField] private CharacterManager characterManager;
	[SerializeField] private Light lightTorch;
	[SerializeField] private Image chargeBar;
	public bool isTorch {get; private set;} = true;
	private bool isPicked = false;
	public float charge = 7;
	
	
	void Update()
	{
		if(torch.isInteract)
		{
			RaiseTorch(); 
			torch.isInteract = false;	
			isPicked = true;
		}
		ActiveTorch();
	}
	private void RaiseTorch()
	{
		lightTorch.enabled = true;
	}
	
	private void ActiveTorch()
	{
		if (!isPicked)
		{
			return;
		}
		if (characterManager.IAActiveTorch.WasPressedThisFrame())
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
}
