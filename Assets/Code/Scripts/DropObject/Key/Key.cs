using System.Collections;
using TMPro;
using UnityEngine;

public class Key : ObjectWhichDrop, IActivate
{
	[SerializeField] private GameObject myDoor;
	[SerializeField] private GameObject myTriggerDoor;
	[SerializeField] private TMP_Text hand;
	[SerializeField] private string door;

	void Update()
	{
		Hand();
	}
	private void Hand()
	{
		if (!isInteract){return;}
		if(characterManager.triggetForDropObject == myTriggerDoor)
		{
			activeComment.text = "Нажать ЛКМ чтобы открыть";
		}
		else
		{
			activeComment.text = "";
		}
	}
	public void ActiveObject()
	{
		
		if(characterManager.triggetForDropObject != myTriggerDoor){return;}
		transform.position = new Vector3(1000, 1000, 1000);
		myTriggerDoor.SetActive(false);
		StartCoroutine(OpenDoorWithDelay());
		characterManager.triggetForDropObject = null;
	}
	private IEnumerator OpenDoorWithDelay()
	{
		myDoor.GetComponent<Animator>().SetBool("IsUnLock", true);
		yield return new WaitForSeconds(0.5f);
		myDoor.GetComponent<Animator>().SetBool("IsUnLock", false);
	}
	public override void DropObject()
	{
		base.DropObject();
		hand.text = "";
	}
	public override void InteractObject()
	{
		base.InteractObject();
		hand.text += "Ключ открывает дверь: " + door;
	}
}
