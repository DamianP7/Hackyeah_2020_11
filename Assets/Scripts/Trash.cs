using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum TrashType
{
	Paper = 0,
	Glass = 1,
	MetalAndPlastic = 2,
}

public class Trash : MonoBehaviour
{
	//public Tooltip tooltip;
	public Animator animator;
	public Transform sprite;
	public GameObject coin;

	[Space]
	public int points;

	[Header("Trash stats")]
	public string trashName;
	public TrashType trashType;
	public float minScale;
	[Tooltip("By how many percent the beam power will be reduced")]
	[Range(0, 0.8f)]
	public float hardness;

	float wrongHitTimer;
	bool hittable;

	private void Start()
	{
		wrongHitTimer = 0;
		hittable = true;
		animator.enabled = false;
	}

	public void Hitted(TrashType beamType, float force)
	{
		if (!hittable)
			return;

		if (beamType != trashType)
		{
			wrongHitTimer += Time.deltaTime;
			LevelManager.Instance.WrongTypeShot(trashName, wrongHitTimer);
			return;
		}

		float totalForce = force * (1 - hardness) * Time.deltaTime;

		sprite.localScale *= (1 - totalForce);

		if (sprite.localScale.x < minScale)
			Destroyed();
	}

	public void Destroyed()
	{
		animator.enabled = true;
		hittable = false;
		animator.SetTrigger("Destroyed");

		Destroy(this.gameObject, 2);
	}

	public void DisableSprite()
	{
		sprite.gameObject.SetActive(false);
	}
	
	public void GivePoints()
	{
		CharacterController.Player.Points += points;
	}
}
