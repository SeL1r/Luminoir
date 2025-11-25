using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
	[SerializeField] private GameObject mainCamera;
	private InputAction IAMove, IALook;
	private Rigidbody rb;
	private int speedCharacter = 4;
	[SerializeField] private SettingsManager settingsManager;
	
	
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
		Vector3 move = new Vector3(valueVelocity.x * speedCharacter, rb.linearVelocity.y, valueVelocity.y * speedCharacter);
		Vector3 moveVelocity = transform.TransformDirection(move);
		rb.linearVelocity = moveVelocity;
	}
	
	private void RotateCharacter()
	{
		Vector2 valueRotate = IALook.ReadValue<Vector2>();
		Vector3 valueRotateY = new Vector3(0, valueRotate.x * Time.deltaTime * settingsManager.Sensitivity, 0);
		Vector3 valueRotateX = new Vector3(-valueRotate.y * Time.deltaTime * settingsManager.Sensitivity, 0, 0);
		gameObject.transform.Rotate(valueRotateY, Space.Self);
		mainCamera.transform.Rotate(valueRotateX, Space.Self);
		
	}
}
