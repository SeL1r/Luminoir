using UnityEditor.Build;
using UnityEngine;

public class Lighter : ObjectWhichDrop, IActivate
{
	[SerializeField] private GameObject fire;
	[SerializeField] private GameObject fireTrigger, candleTrigger;
	[SerializeField] private GameObject[] candle;
	public bool isFire{get; private set;} = false;
	public bool isCandle{get; private set;} = false;
	public void ActiveObject()
	{
		if(characterManager.triggetForDropObject == fireTrigger)
		{
			fireTrigger.SetActive(false);
			fire.GetComponent<ParticleSystem>().Play();
			fire.GetComponent<AudioSource>().enabled = true;
			isFire = true;
		}
		
		if(characterManager.triggetForDropObject == candleTrigger)
		{
			foreach (GameObject obj in candle)
			{
				obj.SetActive(true);
				candleTrigger.SetActive(false);
				isCandle = true;
			}
		}
	}
}
