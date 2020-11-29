using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	private static AudioManager instance;
	public static AudioManager Instance
	{
		get
		{
			if (instance == null)
				instance = FindObjectOfType<AudioManager>();
			return instance;
		}
	}

	public AudioClip music;
	public AudioSource musicSource;
	public AudioSource soundSource;

	public bool selfCheck = false;

	private void Start()
	{
		if(selfCheck)
		{
			if (PlayerPrefs.GetInt("Music", 1) > 0)
			{
				musicSource.volume = 1;
				soundSource.volume = 1;
			}
			else
			{
				musicSource.volume = 0;
				soundSource.volume = 0;
			}
		}	
		musicSource.clip = music;
		musicSource.Play();
	}

	public void TurnMusic(bool enabled)
	{
		musicSource.volume = enabled ? 1 : 0;
	}

	public void TurnSounds(bool enabled)
	{
		soundSource.volume = enabled ? 1 : 0;
		CharacterController.Player.weaponAudio.volume = enabled ? 1 : 0;
	}

	public void PlaySound(AudioClip audioClip)
	{
		soundSource.clip = audioClip;
		soundSource.Play();
	}
}
