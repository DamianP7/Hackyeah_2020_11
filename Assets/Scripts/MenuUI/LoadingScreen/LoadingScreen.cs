using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	private static LoadingScreen instance;
	public static LoadingScreen Instance
	{
		get
		{
			if (instance == null)
				instance = FindObjectOfType<LoadingScreen>();
			return instance;
		}
	}

	public ControlManager controlManager;
	public ControlManager.InputState nextInputState;

	public CanvasGroup[] canvasGroupsToHide;

	[Header("Internal Variables")]
	public Animator animator;
	public LoadingTips loadingTips;
	public Text tipText;
	public CanvasGroup textsGroup;
	public GameObject background;

	public float alphaChange;

	public GameObject pressAnyKey;
	public GameObject tapAnywhere;

	AsyncOperation async;

	bool showTexts = false;
	bool loaded = false;

	void Start()
	{
		controlManager.inputState = nextInputState;
		tipText.text = loadingTips.GetRandomTip();
		animator.SetTrigger("FadeOut");
		for (int i = 0; i < canvasGroupsToHide.Length; i++)
		{
			canvasGroupsToHide[i].alpha = 1;
		}
	}

	public void LoadScene(string name)
	{
		if (async != null)
			return;

		controlManager.inputState = ControlManager.InputState.Loading;
		animator.SetTrigger("FadeIn");
		async = SceneManager.LoadSceneAsync(name);
		async.allowSceneActivation = false;

		for (int i = 0; i < canvasGroupsToHide.Length; i++)
		{
			canvasGroupsToHide[i].alpha = 0;
		}

		StartCoroutine(WaitForLoad());
	}

	public void OnClickContinue()
	{
		if (!loaded)
			return;

		showTexts = false;
		StartCoroutine(WaitForOpen());
	}

	private void Update()
	{
		if (showTexts)
		{
			if (textsGroup.alpha < 1)
				textsGroup.alpha += alphaChange * Time.deltaTime;
		}
		else
		{
			if (textsGroup.alpha > 0)
				textsGroup.alpha -= alphaChange * Time.deltaTime;
		}
	}

	IEnumerator WaitForLoad()
	{
		showTexts = true;
		while (async.progress < 0.9f)
		{
			yield return null;
		}
		loaded = true;

#if UNITY_ANDROID
		tapAnywhere.SetActive(true);
#else
		pressAnyKey.SetActive(true);
#endif
	}

	IEnumerator WaitForOpen()
	{
		while (textsGroup.alpha > 0)
		{
			yield return null;
		}
		async.allowSceneActivation = true;
	}
}
