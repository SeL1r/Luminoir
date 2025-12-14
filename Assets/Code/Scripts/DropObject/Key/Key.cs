using System.Collections;
using UnityEngine;

public class Key : ObjectWhichDrop, IActivate
{
	[SerializeField] private GameObject myDoor;
	[SerializeField] private GameObject myTriggerDoor;
	public void ActiveObject()
	{
		
		if(characterManager.triggetForDropObject != myTriggerDoor){return;}
		transform.position = new Vector3(1000, 1000, 1000);
		myTriggerDoor.SetActive(false);
		StartCoroutine(OpenDoorWithDelay());
	}
	private IEnumerator OpenDoorWithDelay()
	{
		myDoor.GetComponent<Animator>().SetBool("IsUnLock", true);
		yield return new WaitForSeconds(0.5f);
		myDoor.GetComponent<Animator>().SetBool("IsUnLock", false);
	}
}
