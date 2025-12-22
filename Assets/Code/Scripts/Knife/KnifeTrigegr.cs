using UnityEngine;

public class KnifeTrigegr : MonoBehaviour
{
	[SerializeField] private Knife knife;
	private void OnTriggerEnter(Collider other)
	{
		knife.OnTrigger();
	}
}
