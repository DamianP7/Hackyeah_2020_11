using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
	public string worldName;

	public void OnClickPlanet()
	{
		LoadingScreen.Instance.LoadScene(worldName);
	}
}
