using UnityEngine;

public class SettingsManager : MonoBehaviour
{
	private float _sensitivity = 1;
	public float Sensitivity
	{
		get 
		{ 
			return _sensitivity; 
		}
		set 
		{ 
			_sensitivity = value;
			_sensitivity = Mathf.Clamp(_sensitivity, 1, 15);
			PlayerPrefs.SetFloat("_sensitivity", _sensitivity); 
		}
	}
	void Start()
	{
		UploadFromPlayerPrefs();
	}
	
	private void UploadFromPlayerPrefs()
	{
		if(PlayerPrefs.HasKey("_sensitivity"))
		{
			Sensitivity = PlayerPrefs.GetFloat("_sensitivity");
		}
	}
}
