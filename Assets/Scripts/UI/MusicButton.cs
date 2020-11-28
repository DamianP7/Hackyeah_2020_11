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
            // music on
            disabled.SetActive(false);
            musicEnabled = true;
        }
        else
        {
            // music off
            disabled.SetActive(true);
            musicEnabled = false;
        }
    }

    public void OnButtonClick()
    {
        musicEnabled = !musicEnabled;
        // change music state

        PlayerPrefs.SetInt("Music", musicEnabled ? 1 : 0);
    }
}
