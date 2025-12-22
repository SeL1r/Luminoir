using UnityEngine;
using TMPro;

public class ObjectWhichDrop : MonoBehaviour, IDroptable, IInteractable
{
	private Rigidbody rb;
	public CharacterManager characterManager {get; private set;}
	[SerializeField] private Transform arm;
	[SerializeField] private Transform characterDropPos;
	public TMP_Text activeComment;
	public bool isInteract{get; private set;} = false;
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
	public virtual void DropObject()
	{
		transform.position = characterDropPos.position;
		rb.AddForce(characterDropPos.forward * dropForce, ForceMode.Impulse);
		isInteract = false;
	}
	public virtual void InteractObject()
	{
		transform.position = arm.position;
		transform.rotation = arm.rotation;
		isInteract = true;
	}
}
