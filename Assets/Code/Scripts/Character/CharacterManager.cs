using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
	[SerializeField] private GameObject head;
	private InputAction IAMove, IALook;
	public InputAction IAInteract{get; private set;}
	public InputAction IAActiveTorch{get; private set;}
	private Rigidbody rb;
	private int speedCharacter = 2;
	[SerializeField] private SettingsManager settingsManager;
	private float maxHeadAngle;
	public GameObject hitObject {get;private set;} 
	[SerializeField] private LayerMask interactableLayer;
	
	
	void Start()
	{
		InitializationVariables();
	}
	
	private void InitializationVariables()
	{
	   IAMove = InputSystem.actions.FindAction("Move"); 
	   IALook = InputSystem.actions.FindAction("Look");
	   IAInteract = InputSystem.actions.FindAction("Interact");
	   IAActiveTorch = InputSystem.actions.FindAction("ActiveTorch");
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
		if (Physics.Raycast(ray, out hit, 2.1f, interactableLayer))
		{
			hitObject = hit.collider.gameObject;
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
}
