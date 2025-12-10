using UnityEngine;
using UnityEngine.UI;

public class CharacterSanity : MonoBehaviour
{
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
	
	void Update()
	{
		
		SanityReduction();
	}
	private void SanityReduction()
	{
		if (lightTorch.intensity <= 0.001 || !lightTorch.enabled)
		{
			Sanity = Mathf.MoveTowards(Sanity, 0, 1 * Time.deltaTime);
		}
		sanityImage.fillAmount = Sanity / 100;
	}
}
