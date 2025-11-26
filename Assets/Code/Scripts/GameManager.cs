using UnityEngine;

public class GameManager : MonoBehaviour
{
	
	void Start()
	{
		LockCursoudInStartGame();
	}
	
	private void LockCursoudInStartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
    }

	void Update()
	{
		
	}
}
