using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	void Start()
	{
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}
	public void OnClickStart()
	{
		SceneManager.LoadScene("SampleScene");
	}
	public void OnClickExit()
	{
		Application.Quit();
	}
}
