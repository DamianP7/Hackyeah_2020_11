using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : MonoBehaviour
{
    public GameObject disabled;
    bool musicEnabled;

    void Start()
    {
        if(PlayerPrefs.GetInt("Music",1) > 0)
        {
            AudioManager.Instance.TurnMusic(true);
            disabled.SetActive(false);
            musicEnabled = true;
        }
        else
        {
            AudioManager.Instance.TurnMusic(false);
            disabled.SetActive(true);
            musicEnabled = false;
        }
    }

    public void OnButtonClick()
    {
        musicEnabled = !musicEnabled;

        disabled.SetActive(!musicEnabled);
        AudioManager.Instance.TurnMusic(musicEnabled);
        PlayerPrefs.SetInt("Music", musicEnabled ? 1 : 0);
    }
}
