using System.Collections;
using System.Collections.Generic;
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

	[Header("Trash stats")]
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
	}

	public void Hitted(TrashType beamType, float force)
	{
		if (!hittable)
			return;

		if (beamType != trashType)
		{
			wrongHitTimer += Time.deltaTime;
			return;
		}

		float totalForce = force * (1 - hardness) * Time.deltaTime;
		Debug.Log(totalForce);
		sprite.localScale *= 1 - totalForce;

		if (sprite.localScale.x < minScale)
			Destroyed();
	}

	public void Destroyed()
	{
		hittable = false;
		//animator

		Destroy(this.gameObject, 2);
	}
}
