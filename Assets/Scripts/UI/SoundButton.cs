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
            // music on
            disabled.SetActive(false);
            soundEnabled = true;
        }
        else
        {
            // music off
            disabled.SetActive(true);
            soundEnabled = false;
        }
    }

    public void OnButtonClick()
    {
        soundEnabled = !soundEnabled;
        // change music state

        PlayerPrefs.SetInt("Sound", soundEnabled ? 1 : 0);
    }
}
