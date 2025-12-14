using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSanity : MonoBehaviour
{
	private float lossRateSanity = 1;
	private float _sanity = 100;
	public float Sanity 
	{
		get
		{
			return _sanity;
		}
		set
		{
			_sanity = value;
			_sanity = Mathf.Clamp(_sanity, 0, 100);
		}
	}
	[SerializeField] private Image sanityImage;
	[SerializeField] private Light lightTorch;
	[SerializeField] private GameObject fire;
	[SerializeField] private Lighter lighter;
	[SerializeField] private GameObject warping;
	
	void Start()
	{
		StartCoroutine(SanityReduction());
	}
	IEnumerator SanityReduction()
	{
		while (true)
		{
			if ((lightTorch.intensity <= 0.001 || !lightTorch.enabled) && (!lighter.isFire || lighter.isFire && (Vector3.Distance(fire.transform.position, transform.position) > 5)))
			{
				Sanity = Mathf.MoveTowards(Sanity, 0, lossRateSanity * 0.1f);
			}
			sanityImage.fillAmount = Sanity / 100;
			yield return new WaitForSecondsRealtime(0.1f);
			if (Sanity >= 30) 
			{
				warping.SetActive(false);
				continue;
			}
			warping.SetActive(true);			
		}
	}
}
