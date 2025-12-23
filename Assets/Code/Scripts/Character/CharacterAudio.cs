using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
	[SerializeField] private AudioSource footStep;
	private Vector3 previousPos;
	private bool isMove = true;
	
	private void Start()
	{
		StartCoroutine(Audio());
		previousPos = transform.position;
	}
	IEnumerator Audio()
	{
		while (true)
		{
			yield return new WaitForSecondsRealtime(0.1f);
			if(previousPos != transform.position && isMove)
			{
				footStep.Play();
				isMove = false;
			}
			else if(previousPos == transform.position)
			{
				footStep.Stop();
				isMove = true;
			}
			previousPos = transform.position;
		}
	}
}