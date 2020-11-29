using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableIfPlatform : MonoBehaviour
{
    public GameObject gameObj;

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        gameObj.SetActive(false);
#endif
    }
}
