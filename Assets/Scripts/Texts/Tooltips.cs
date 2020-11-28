using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Tooltips")]
public class Tooltips : ScriptableObject
{
	public List<TooltipInfo> tooltips;

	public string GetTooltipText(string trash)
	{
		if (tooltips.FindIndex(x => x.trashName == trash) != -1)
			return tooltips.Find(x => x.trashName == trash).tooltip;
		else
		{
			Debug.LogError("Can't find tooltip");
			return "none";
		}
	}

	public Sprite GetImage(string trash)
	{
		if (tooltips.FindIndex(x => x.trashName == trash) != -1)
			return tooltips.Find(x => x.trashName == trash).image;
		else
		{
			Debug.LogError("Can't find tooltip");
			return null;
		}
	}
	public TooltipInfo GetTooltip(string trash)
	{
		if (tooltips.FindIndex(x => x.trashName == trash) != -1)
			return tooltips.Find(x => x.trashName == trash);
		else
		{
			Debug.LogError("Can't find tooltip");
			return null;
		}
	}

}

[Serializable]
public class TooltipInfo
{
	public string trashName;
	public string tooltip;
	public Sprite image;
}

public static class TrashNames
{
	public static string BOTTLE = "Bottle";
}