using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] private AudioSource openDoor;
	private Quaternion prevityRot;
	void Start()
	{
		StartCoroutine(OpenDoop());
		prevityRot = transform.rotation;
	}
	IEnumerator OpenDoop()
	{
		while (true)
		{
			yield return new WaitForSecondsRealtime(0.1f);
			if(prevityRot != transform.rotation)
			{
				openDoor.Play();
				break;
			}
			prevityRot = transform.rotation;
		}
	}
}
