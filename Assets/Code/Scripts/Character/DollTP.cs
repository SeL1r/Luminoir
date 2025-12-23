using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DollTP : MonoBehaviour
{
	[SerializeField] private Animator animatorDoll;
	[SerializeField] private List<GameObject> triggerDoll;
	[SerializeField] private List<AudioSource> laughter;
	private int i = 2;
	private void OnTriggerEnter(Collider other)
	{
		foreach (var trigger in triggerDoll)
		{
			if (trigger == other.gameObject)
			{
				triggerDoll.Remove(trigger);
				animatorDoll.SetBool("Pos" + i.ToString(), true);
				i++;
				laughter[Random.Range(0, 2)].Play();
				break;
			}
		}
	}
}
