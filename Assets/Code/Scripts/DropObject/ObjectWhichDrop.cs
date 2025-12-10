using UnityEngine;

public class ObjectWhichDrop : MonoBehaviour, IDroptable, IInteractable
{
	private Rigidbody rb;
	public CharacterManager characterManager {get; private set;}
	[SerializeField] private Transform arm;
	[SerializeField] private Transform characterDropPos;
	private float dropForce = 1;

	void Start()
	{
		InitializationVariables();
	}
	private void InitializationVariables()
	{
	   rb = GetComponent<Rigidbody>();
	   characterManager = FindAnyObjectByType<CharacterManager>();
	}
	public void DropObject()
	{
		transform.position = characterDropPos.position;
		rb.AddForce(characterDropPos.forward * dropForce, ForceMode.Impulse);
	}
	public void InteractObject()
	{
		transform.position = arm.position;
		transform.rotation = arm.rotation;
	}
}
