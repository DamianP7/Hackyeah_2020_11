using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : MonoBehaviour
{
	private static PauseWindow instance;
	public static PauseWindow Instance
	{
		get
		{
			if (instance == null)
				instance = FindObjectOfType<PauseWindow>();
			return instance;
		}
	}

	public CanvasGroup canvasGroup;


	public void Open()
	{
		Time.timeScale = 0;
		canvasGroup.alpha = 1;
	}

	public void Close()
	{
		Time.timeScale = 1;
		canvasGroup.alpha = 0;
	}

	public void Exit()
	{
		Time.timeScale = 1;
		canvasGroup.alpha = 0;
		LoadingScreen.Instance.LoadScene("Space");
	}
}
