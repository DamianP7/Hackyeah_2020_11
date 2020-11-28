using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	private static LevelManager instance;
	public static LevelManager Instance
	{
		get
		{
			if (instance == null)
				instance = FindObjectOfType<LevelManager>();
			return instance;
		}
	}

	[Header("Tooltips")]
	public Tooltip tooltip;
	[SerializeField] Tooltips tooltips;
	public float timeToShowTooltip;

	[Header("Tooltips")]
	public Text points;

	public void WrongTypeShot(string trash, float time)
	{
		if (time < timeToShowTooltip)
			return;

		TooltipInfo info = tooltips.GetTooltip(trash);
		tooltip.Show(info.image, info.tooltip);
	}

}
