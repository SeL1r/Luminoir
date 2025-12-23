using System;
using UnityEngine;

public class Battery : MonoBehaviour, IInteractable
{
	[SerializeField] private TorchInHead torchInHead;
	[SerializeField] private AudioSource pickUp;
	public void InteractObject()
	{
		torchInHead.charge = torchInHead.maxChargeValue;
		pickUp.Play();
		transform.position = new Vector3(1000,1000,1000);
	}
}
