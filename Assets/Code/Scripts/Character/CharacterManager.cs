using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
	[SerializeField] private GameObject head;
	private InputAction IAMove, IALook, IAInteract, IADrop;
	private Rigidbody rb;
	private int speedCharacter = 2;
	[SerializeField] private SettingsManager settingsManager;
	private float maxHeadAngle;
	public GameObject hitObject {get;private set;} 
	[SerializeField] private LayerMask interactableLayer;
	[SerializeField] private CharacterArm characterArm;
	
	
	void Start()
	{
		InitializationVariables();
	}
	
	private void InitializationVariables()
	{
	   IAMove = InputSystem.actions.FindAction("Move"); 
	   IALook = InputSystem.actions.FindAction("Look");
	   IAInteract = InputSystem.actions.FindAction("Interact");
	   IADrop = InputSystem.actions.FindAction("Drop");
	   rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() 
	{
		MoveCharacter();
	}
	
	void Update()
	{
		RotateCharacter();
		Raycast();
		Interact();
		DropObject();
	}
	
	private void MoveCharacter()
	{
		Vector2 valueVelocity = IAMove.ReadValue<Vector2>();
		Vector3 move = transform.rotation * new Vector3(valueVelocity.x * speedCharacter, rb.linearVelocity.y, valueVelocity.y * speedCharacter);
		rb.linearVelocity = move;
	}
	
	private void RotateCharacter()
	{
		Vector2 mouseDelta = IALook.ReadValue<Vector2>() * Time.deltaTime * settingsManager.Sensitivity;
		if (mouseDelta != Vector2.zero)
		{
			maxHeadAngle = Mathf.Clamp(maxHeadAngle - mouseDelta.y, -75, 75);
			head.transform.localRotation = Quaternion.Euler(maxHeadAngle, 0, 0);
			transform.Rotate(0, mouseDelta.x, 0);
		}		
	}
	
	private void Raycast()
	{
		Vector3 centerPoint = new Vector3(Screen.width / 2, Screen.height / 2, 0);
		Ray ray = Camera.main.ScreenPointToRay(centerPoint);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 2, interactableLayer))
		{
			hitObject = hit.collider.gameObject;
		}
		else
		{
			hitObject = null;
		}
	}
	
	private void Interact()
	{
		if(!IAInteract.WasPressedThisFrame())
		{
			return;
		}
		if(hitObject == null)
		{
			return;
		}
		if(hitObject.TryGetComponent<IInteractable>(out IInteractable interactable))
		{
			interactable.InteractObject();
		}
	}
	private void DropObject()
	{
		if(!IADrop.WasPressedThisFrame())
		{
			return;
		}
		if(characterArm.objectInArm == null)
		{
			return;
		}
		if(characterArm.objectInArm.TryGetComponent<IDroptable>(out IDroptable idroptable))
		{
			idroptable.DropObject();
		}
	}
}
