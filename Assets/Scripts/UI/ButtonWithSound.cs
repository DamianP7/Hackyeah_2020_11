using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWithSound : MonoBehaviour
{
	public AudioClip sound;

	public void MakeSound()
	{
		AudioManager.Instance.PlaySound(sound);

	}
}
