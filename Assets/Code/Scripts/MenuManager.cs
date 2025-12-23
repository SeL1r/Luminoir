using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	private InputAction IAPause;
	[SerializeField] private GameObject menu;
	[SerializeField] private GameObject settingsMenu;
	[SerializeField] private SettingsManager settingsManager;
	private bool isMenuActive = true;
	void Start()
	{
		InitializationVariables();
	}
	
	private void InitializationVariables()
	{
		IAPause = InputSystem.actions.FindAction("Pause");
	}

	void Update()
	{
		ClickPause();
	}
	private void ClickPause()
	{
		if(!IAPause.WasPressedThisFrame()){return;}
		if(isMenuActive)
		{
			Time.timeScale = 0;
			menu.SetActive(true);
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
			isMenuActive = false;
		}
		else
		{
			Time.timeScale = 1;
			menu.SetActive(false);
			settingsMenu.SetActive(false);
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			isMenuActive = true;
		}
	}
	
	
	public void OnClickQuit()
	{
		SceneManager.LoadScene("MainMenu");
	}
	public void OnClickContinue()
	{
		Time.timeScale = 1;
		menu.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		isMenuActive = true;
	}
	public void OnClickSettings()
	{
		menu.SetActive(false);
		settingsMenu.SetActive(true);
		settingsManager.LoadVisualSettings();
	}
	public void OnClickCancelInSettingsMenu()
	{
		menu.SetActive(true);
		settingsMenu.SetActive(false);
	}
}
