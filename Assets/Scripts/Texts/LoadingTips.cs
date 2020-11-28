using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LoadingTips")]
public class LoadingTips : ScriptableObject
{
	public List<string> loadingTips;

	public string GetRandomTip()
	{
		return loadingTips[Random.Range(0, loadingTips.Count)];
	}
}
