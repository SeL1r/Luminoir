using Unity.VisualScripting;
using UnityEngine;

public class CharacterArm : MonoBehaviour
{
	public bool inArm = false;
	public GameObject objectInArm {get; private set;}
	private void OnTriggerEnter(Collider other)
	{
		objectInArm = other.gameObject;
		inArm = true;
	}
	private void OnTriggerExit()
	{
		objectInArm = null;
		inArm = false;
	}
}
