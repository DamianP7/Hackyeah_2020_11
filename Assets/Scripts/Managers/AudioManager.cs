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

	private void Start()
	{
		musicSource.clip = music;
		musicSource.Play();
	}

	public void Refresh()
	{

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
}
