using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWindow : MonoBehaviour
{
	public Animator animator;
	bool opened = false;

	public void OnWindowClick()
	{
		opened = !opened;
		if (opened)
			animator.SetTrigger("Open");
		else
			animator.SetTrigger("Close");
	}
}
