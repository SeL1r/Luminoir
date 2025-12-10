using Unity.VisualScripting;
using UnityEngine;

public class CharacterArm : MonoBehaviour
{
	public GameObject objectInArm {get; private set;}
	private void OnTriggerEnter(Collider other)
	{
		objectInArm = other.gameObject;
	}
	private void OnTriggerExit()
	{
		objectInArm = null;
	}
}
