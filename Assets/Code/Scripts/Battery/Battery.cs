using System;
using UnityEngine;

public class Battery : MonoBehaviour, IInteractable
{
	[SerializeField] private TorchInHead torchInHead;
	public void InteractObject()
	{
		torchInHead.charge = 7;
		gameObject.SetActive(false);
	}
}
