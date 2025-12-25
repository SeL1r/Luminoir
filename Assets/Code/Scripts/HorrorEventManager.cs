using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HorrorEventManager : MonoBehaviour
{
	[SerializeField] private List<AudioSource> horrorEvent;
	[SerializeField] private Transform character;
	[SerializeField] private TMP_Text comment;
	private bool isStartHorrorEvent = false;
	private int horrorIndex;


	private void Start()
	{
		StartCoroutine(StartHorrorEvent());
	}
	void Update()
	{
		UnActiveHorrorEvent();
	}
	
	private void UnActiveHorrorEvent()
	{
		if(!isStartHorrorEvent){return;}
		if(!(Vector3.Distance(horrorEvent[horrorIndex].gameObject.transform.position, character.position) <= 1)){return;}
		comment.text = "Нажмите Е чтобы выключить";
		if(!Input.GetKeyDown(KeyCode.E)){return;}
		comment.text = "";
		isStartHorrorEvent = false;
		horrorEvent[horrorIndex].Stop();
	}
	IEnumerator StartHorrorEvent()
	{
		while(true)
		{
			yield return new WaitForSecondsRealtime(Random.Range(30,60));
			isStartHorrorEvent = true;
			horrorIndex = Random.Range(0, horrorEvent.Count);
			horrorEvent[horrorIndex].Play();
		}
	}
}
