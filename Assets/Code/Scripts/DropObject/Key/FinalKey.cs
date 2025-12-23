using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalKey : Key
{
	[SerializeField] private GameObject finalGameUI, finalGameTextUI;
	public override void ActiveObject()
	{
		base.ActiveObject();
		finalGameUI.SetActive(true);
		StartCoroutine(QuitGame());
	}
	IEnumerator QuitGame()
	{
		yield return new WaitForSecondsRealtime(2);
		finalGameTextUI.SetActive(true);
		yield return new WaitForSecondsRealtime(2);
		SceneManager.LoadScene("MainMenu");
	}
}
