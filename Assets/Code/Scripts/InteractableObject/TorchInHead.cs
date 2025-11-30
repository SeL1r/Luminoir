using UnityEngine;

public class TorchInHead : MonoBehaviour
{
	[SerializeField] private Torch torch;
	[SerializeField] private CharacterManager characterManager;
	private Light lightTorch;
	private bool isTorch = true, isActive = true;
	
	
	private void Start()
	{
		lightTorch = GetComponent<Light>();
	}
	void Update()
	{
		if(torch.isInteract && isActive)
		{
			RaiseTorch(); 
			torch.isInteract = false;	 	
		}
		ActiveTorch();
	}
	private void RaiseTorch()
	{
		lightTorch.enabled = true;
	}
	
	private void ActiveTorch()
	{
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
	}
}
