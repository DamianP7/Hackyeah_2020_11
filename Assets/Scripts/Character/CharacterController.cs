using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public Transform padPointer;
	public Transform mousePointer;
	public float maxPointerDistance;

	[SerializeField] float speed = 1;

	int hp = 100;
	Rigidbody2D rb;
	Transform currentPointer;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}


	public void Aim(Vector2 direction, bool isMouse = false)
	{
		padPointer.gameObject.SetActive(!isMouse);
		mousePointer.gameObject.SetActive(isMouse);

		if (isMouse)
		{
			currentPointer = mousePointer;

			currentPointer.position = direction;
		}
		else
		{
			currentPointer = padPointer;
			currentPointer.localPosition = direction * maxPointerDistance;

		}
	}

	public void Move(Vector2 direction)
	{
		Vector3 pos = new Vector3(direction.x * speed, direction.y * speed) + rb.transform.position;
		rb.MovePosition(pos);
	}

	public void Shoot()
	{

	}

	void MovePointer(Vector2 position, bool isMouse)
	{
		padPointer.gameObject.SetActive(!isMouse);
		mousePointer.gameObject.SetActive(isMouse);

		if (isMouse)
			currentPointer = mousePointer;
		else
			currentPointer = padPointer;

		currentPointer.position = position;
	}

}
