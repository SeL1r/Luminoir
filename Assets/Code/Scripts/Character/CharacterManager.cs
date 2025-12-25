using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
	[SerializeField] private GameObject head;
	private InputAction IAMove, IALook, IAInteract, IADrop, IAActive;
	private Rigidbody rb;
	private int speedCharacter = 2;
	[SerializeField] private SettingsManager settingsManager;
	private float maxHeadAngle;
	public GameObject hitObjectInteract {get;private set;}
	public GameObject hitObjectDrop {get;private set;}
	public GameObject triggetForDropObject;
	[SerializeField] private LayerMask interactableLayer, droptableLayer, allLayers;
	[SerializeField] private CharacterArm characterArm;
	private int maxHeadAngleUp = 75, maxHeadAngleDown = -75;
	private float distanceRay = 2f;
	[SerializeField] private TMP_Text comment;
	private bool interactTryGet, dropTryGet;
	GameObject inFront;
	IInteractable interactableInFront;
	IDroptable droptableInFront;
	
	
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
	   IAActive = InputSystem.actions.FindAction("Active");
	   rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() 
	{
		MoveCharacter();
	}
	
	void Update()
	{
		RotateCharacter();
		CheckIfThereObjectInFront();
		Interact();
		DropObject();
		Active();
	}
	private void OnTriggerEnter(Collider other)
	{
		triggetForDropObject = other.gameObject;
	}
	private void OnTriggerExit(Collider other)
	{
		triggetForDropObject = null;
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
			maxHeadAngle = Mathf.Clamp(maxHeadAngle - mouseDelta.y, maxHeadAngleDown, maxHeadAngleUp);
			head.transform.localRotation = Quaternion.Euler(maxHeadAngle, 0, 0);
			transform.Rotate(0, mouseDelta.x, 0);
		}		
	}
	
	private void CheckIfThereObjectInFront()
	{
		GameObject inFrontNew = ObjectInFront(distanceRay, allLayers);
		if (inFrontNew == inFront){return;}
		inFront = inFrontNew;
		if (inFront == null)
		{ 
			interactableInFront = null; 
			droptableInFront = null;
			comment.text = "";
			return;
		}
		interactableInFront = inFront.GetComponent<IInteractable>();
		if (inFront.TryGetComponent<IDroptable>(out IDroptable droptable))
		{
			droptableInFront = droptable;
			if(characterArm.inArm){comment.text = "Нажать Q чтобы выкинуть предмет";}
			else{comment.text = "Нажать Е чтобы подобрать";}
			return;
		}
		comment.text = "";
	}
	
	
	
	
	
	private GameObject ObjectInFront(float distanceRay, LayerMask layerMask)
	{
		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, distanceRay, layerMask))
		{
			return hit.collider.gameObject;
		}
		return null;
	}
	
	private void Interact()
	{
		if(!IAInteract.WasPressedThisFrame()){return;}
		if(droptableInFront != null && !characterArm.inArm && interactableInFront != null){interactableInFront.InteractObject(); return;}
		if(interactableInFront != null){interactableInFront.InteractObject();}
		
	}
	private void DropObject()
	{
		if(!IADrop.WasPressedThisFrame()){return;}
		if(characterArm.objectInArm == null){return;}
		if(characterArm.objectInArm.TryGetComponent<IDroptable>(out IDroptable idroptable))
		{
			idroptable.DropObject();
		}
	}
	private void Active()
	{
		if(characterArm.objectInArm == null){return;}
		if(triggetForDropObject == null){return;}
		if(!IAActive.WasPressedThisFrame()){return;}
		if(characterArm.objectInArm.TryGetComponent<IActivate>(out IActivate iactivate))
		{
			iactivate.ActiveObject();
		}
	}
}
