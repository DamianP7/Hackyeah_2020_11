using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
	public Transform[] planets;
	public float speed = 20;
	int level;

	private void Awake()
	{
		level = PlayerPrefs.GetInt("LastLevel", 0);
		SetShipOnLevel(level);
	}

	private void SetShipOnLevel(int level)
	{
		this.transform.position = planets[level].position;
	}

	void Update()
	{
		transform.RotateAround(planets[level].position, Vector3.forward, speed * Time.deltaTime);
	}
}
