using System;
using UnityEngine;

public class Torch : MonoBehaviour, IInteractable
{
	public bool isInteract;
	
	public void InteractObject()
	{
		isInteract = true;
		gameObject.SetActive(false);
	}
}
