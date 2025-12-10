using UnityEditor.Build;
using UnityEngine;

public class Lighter : MonoBehaviour, IInteractable, IActivate, IDroptable
{
	[SerializeField] private ParticleSystem fire;
	[SerializeField] private Transform arm;
	[SerializeField] private Transform characterDropPos;
	private Rigidbody rb;
	public void InteractObject()
	{
		transform.position = arm.position;
		transform.rotation = arm.rotation;
	}
	public void ActiveObject()
	{
		
	}
	public void DropObject()
	{
		transform.position = characterDropPos.position;
		rb.AddForce(characterDropPos.forward * 2f, ForceMode.Impulse);
	}
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
}
