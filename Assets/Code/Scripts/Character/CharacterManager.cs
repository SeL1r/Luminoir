using System.Runtime.CompilerServices;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
	private InputAction IAMove;
	private Rigidbody rb;
	private int speedCharacter = 4;
	void Start()
	{
		InitializationVariables();
	}
	
	private void InitializationVariables()
	{
	   IAMove = InputSystem.actions.FindAction("Move"); 
	   rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() 
	{
		MoveCharacter();
	}
	
	private void MoveCharacter()
	{
		Vector2 moveValue = IAMove.ReadValue<Vector2>();
		Vector3 move = new Vector3(moveValue.x * speedCharacter, rb.linearVelocity.y, moveValue.y * speedCharacter);
		rb.linearVelocity = move;
	}
	
	void Update()
	{
		
	}
}
