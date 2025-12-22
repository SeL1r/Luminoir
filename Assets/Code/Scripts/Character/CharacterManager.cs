using TMPro;
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
	[SerializeField] private LayerMask interactableLayer, droptableLayer;
	[SerializeField] private CharacterArm characterArm;
	private int maxHeadAngleUp = 75, maxHeadAngleDown = -75;
	private float distanceRay = 1.6f;
	[SerializeField] private TMP_Text comment;
	private bool interactTryGet, dropTryGet;
	
	
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
		Raycast();
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
	
	private void Raycast()
	{
		Vector3 centerPoint = new Vector3(Screen.width / 2, Screen.height / 2, 0);
		Ray ray = Camera.main.ScreenPointToRay(centerPoint);
		RaycastHit hit;
		hitObjectInteract = RayCast(ray, out hit, distanceRay, interactableLayer);
		hitObjectDrop = RayCast(ray, out hit, distanceRay, droptableLayer);
		
		if (hitObjectDrop != null && !characterArm.inArm || hitObjectInteract != null)
		{
			comment.text = "Нажать Е чтобы подобарть";
		}
		else if(hitObjectDrop != null && characterArm.inArm)
		{
			comment.text = "Нажать Q чтобы выкинуть предмет";
		}
		else
		{	
			comment.text = "";		
		}
	}
	private GameObject RayCast(Ray ray, out RaycastHit hit, float distanceRay, LayerMask layerMask)
	{
		GameObject gameObject;
		if (Physics.Raycast(ray, out hit, distanceRay, layerMask))
		{
			gameObject = hit.collider.gameObject;
		}
		else
		{
			gameObject = null;
		}
		return gameObject;
	}
	
	private void Interact()
	{
		if(!IAInteract.WasPressedThisFrame()) {return;}
		InteractInteractable();
		InteractDroptable();
	}
	private void InteractInteractable()
	{
		if(hitObjectInteract == null){return;}
		if(hitObjectInteract.TryGetComponent<IInteractable>(out IInteractable interactable))
		{
			interactable.InteractObject();
		}
	}
	private void InteractDroptable()
	{
		if(hitObjectDrop == null){return;}
		if(characterArm.inArm){return;}
		if(hitObjectDrop.TryGetComponent<IInteractable>(out IInteractable interactable1))
		{
			interactable1.InteractObject();
		}
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
