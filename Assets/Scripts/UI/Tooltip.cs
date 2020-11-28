using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
	public Image image;
	public Text tooltipText;
	public RectTransform rect;

	public float time;
	public float speed;
	public Vector2 hiddenPosition;
	public Vector2 shownPosition;

	Vector2 position;
	bool show = false;

	public void Show(Sprite sprite, string text)
	{
		image.sprite = sprite;
		tooltipText.text = text;

		Show();
	}

	public void Show()
	{
		show = true;
		StartCoroutine(WaitForHide());
	}

	public void Hide()
	{
		show = false;
		StopCoroutine(WaitForHide());
	}

	private void Update()
	{
		if(show)
		{
			if(rect.anchoredPosition.x > shownPosition.x)
			{
				rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - speed * Time.deltaTime, rect.anchoredPosition.y);
			}
		}
		else
		{
			if (rect.anchoredPosition.x < hiddenPosition.x)
			{
				rect.anchoredPosition = new Vector2(rect.anchoredPosition.x + speed * Time.deltaTime, rect.anchoredPosition.y);
			}
		}
	}

	IEnumerator WaitForHide()
	{
		yield return new WaitForSeconds(time);
		show = false;
	}
}
