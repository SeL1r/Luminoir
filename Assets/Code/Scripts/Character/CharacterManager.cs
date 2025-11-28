using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
	[SerializeField] private GameObject head;
	private InputAction IAMove, IALook;
	private Rigidbody rb;
	private int speedCharacter = 2;
	[SerializeField] private SettingsManager settingsManager;
	private float maxHeadAngle;
	
	
	void Start()
	{
		InitializationVariables();
	}
	
	private void InitializationVariables()
	{
	   IAMove = InputSystem.actions.FindAction("Move"); 
	   IALook = InputSystem.actions.FindAction("Look");
	   rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() 
	{
		MoveCharacter();
	}
	
	void Update()
	{
		RotateCharacter();
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
}
