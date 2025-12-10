using UnityEngine;

public class Key : ObjectWhichDrop, IActivate
{
	[SerializeField] private GameObject myDoor;
	[SerializeField] private GameObject myTriggerDoor;
	public void ActiveObject()
	{
		
		if(characterManager.triggetForDropObject != myTriggerDoor)
		{
			return;
		}
		myTriggerDoor.SetActive(false);
		transform.position = new Vector3(1000, 1000, 1000);
		
	}
}
