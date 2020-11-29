using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
	public int sceneIndex;

	public void OnClickPlanet()
	{
		PlayerPrefs.SetInt("LastLevel", sceneIndex - 1);
		LoadingScreen.Instance.LoadScene(sceneIndex);
	}
}
