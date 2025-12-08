using UnityEngine;
using UnityEngine.UI;

public class Torch : MonoBehaviour, IInteractable
{
	public bool isInteract;
	[SerializeField] private GameObject chargeBar, charge, sanity;
	
	public void InteractObject()
	{
		chargeBar.SetActive(true);
		charge.SetActive(true);
		sanity.SetActive(true);
		isInteract = true;
		gameObject.SetActive(false);
	}
}
