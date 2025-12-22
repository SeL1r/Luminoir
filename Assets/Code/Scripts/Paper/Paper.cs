using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour, IInteractable
{
	[SerializeField] private GameObject textInPaper;
	private bool isFinishRead = false;
	private float change;
	private Material instanceMaterial;
	private Renderer material;
	
	private void Start()
	{
		change = GetComponent<Renderer>().material.GetFloat("_transparency");
		material = GetComponent<Renderer>();
		instanceMaterial = new Material(material.material);
		material.material = instanceMaterial;
	}
	private void Update()
	{
		if (isFinishRead)
		{
			change = Mathf.MoveTowards(change, 1, Time.deltaTime);
			material.material.SetFloat("_transparency", change);
		}
		if(change == 1)
		{
			gameObject.SetActive(false);
		}
	}
	public void InteractObject()
	{
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		Time.timeScale = 0;
		textInPaper.SetActive(true);
	}
	public void NextButton()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Time.timeScale = 1;
		textInPaper.SetActive(false);
		isFinishRead = true;
	}
}
