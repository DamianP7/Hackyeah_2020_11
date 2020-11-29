using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
	public Text price;

	public Image[] levels;
	public int[] pricesForLevels;

	public Sprite empty, full;
	public string itemName;
	public Text money;
	int level;

	private void Start()
	{
		level = PlayerPrefs.GetInt(itemName, 1);
		RefreshLevel();
	}

	public void RefreshLevel()
	{
		price.text = pricesForLevels[level].ToString();
		for (int i = 0; i < levels.Length; i++)
		{
			if (i < level)
				levels[i].sprite = full;
			else
				levels[i].sprite = empty;
		}
		money.text = PlayerPrefs.GetInt("Coins", 0).ToString();
	}

	public void OnLevelUpClicked()
	{
		int coins = PlayerPrefs.GetInt("Coins", 0);
		if (coins >= pricesForLevels[level])
		{
			coins -= pricesForLevels[level];
			PlayerPrefs.SetInt("Coins", coins);
			level++;
			PlayerPrefs.SetInt(itemName, level);
			RefreshLevel();
		}
	}
}
