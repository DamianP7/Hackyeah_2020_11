using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    public GameObject disabled;
    bool soundEnabled;

    void Start()
    {
        if(PlayerPrefs.GetInt("Sound",1) > 0)
        {
            AudioManager.Instance.TurnSounds(true);
            disabled.SetActive(false);
            soundEnabled = true;
        }
        else
        {
            AudioManager.Instance.TurnSounds(false);
            disabled.SetActive(true);
            soundEnabled = false;
        }
    }

    public void OnButtonClick()
    {
        soundEnabled = !soundEnabled;

        disabled.SetActive(!soundEnabled);
        AudioManager.Instance.TurnSounds(soundEnabled);
        PlayerPrefs.SetInt("Sound", soundEnabled ? 1 : 0);
    }
}
