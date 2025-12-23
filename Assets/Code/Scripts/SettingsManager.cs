using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
	[SerializeField] private Slider sens;
	[SerializeField] private Slider musicVolume;
	[SerializeField] private Slider masterVolume;
	
	[SerializeField] private AudioSource music;
	[SerializeField] private List<AudioSource> master;
	
	private float _sensitivity = 5;
	public float Sensitivity
	{
		get 
		{ 
			return _sensitivity; 
		}
		set 
		{ 
			_sensitivity = value;
			_sensitivity = Mathf.Clamp(_sensitivity, 1, 20);
			PlayerPrefs.SetFloat("_sensitivity", _sensitivity); 
		}
	}
	
	private float _musicVolume = 10;
	public float MusicVolume
	{
		get 
		{ 
			return _musicVolume; 
		}
		set 
		{ 
			_musicVolume = value;
			_musicVolume = Mathf.Clamp(_musicVolume, 1, 100);
			PlayerPrefs.SetFloat("_musicVolume", _musicVolume); 
		}
	}
	
	private float _masterVolume = 50;
	public float MasterVolume
	{
		get 
		{ 
			return _masterVolume; 
		}
		set 
		{ 
			_masterVolume = value;
			_masterVolume = Mathf.Clamp(_masterVolume, 1, 100);
			PlayerPrefs.SetFloat("_masterVolume", _masterVolume); 
		}
	}
	
	
	void Awake()
	{
		UploadFromPlayerPrefs();
	}
	private void UploadFromPlayerPrefs()
	{
		if(PlayerPrefs.HasKey("_sensitivity")){Sensitivity = PlayerPrefs.GetFloat("_sensitivity");}
		if(PlayerPrefs.HasKey("_musicVolume")){MusicVolume = PlayerPrefs.GetFloat("_musicVolume");}
		if(PlayerPrefs.HasKey("_masterVolume")){MasterVolume = PlayerPrefs.GetFloat("_masterVolume");}
		InitializationValues();
	}
	private void InitializationValues()
	{
		music.volume = MusicVolume/100;
		foreach(AudioSource audioSource in master)
		{
			audioSource.volume = MasterVolume/100;
		}
	}
	
	public void LoadVisualSettings()
	{
		sens.value = Sensitivity/20;
		musicVolume.value = MusicVolume/100;
		masterVolume.value = MasterVolume/100;
	}
	
	public void SaveSettings()
	{
		Sensitivity = sens.value*20;
		MusicVolume = musicVolume.value*100;
		MasterVolume = masterVolume.value*100;
		InitializationValues();
	}
}
