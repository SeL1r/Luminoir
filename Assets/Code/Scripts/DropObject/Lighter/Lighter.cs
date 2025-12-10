using UnityEditor.Build;
using UnityEngine;

public class Lighter : ObjectWhichDrop, IActivate
{
	[SerializeField] private GameObject fire;
	[SerializeField] private GameObject fireTrigger;
	public void ActiveObject()
	{
		if(characterManager.triggetForDropObject != fireTrigger)
		{
			return;
		}
		fireTrigger.SetActive(false);
		fire.GetComponent<ParticleSystem>().Play();
		fire.GetComponent<AudioSource>().enabled = true;
		transform.position = new Vector3(1000, 1000, 1000);
	}
}
