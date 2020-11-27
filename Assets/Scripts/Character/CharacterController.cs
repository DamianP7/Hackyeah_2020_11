using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	public LineRenderer lineRenderer;
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

	private void Start()
	{
		lineRenderer.enabled = false;
	}

	public void Aim(Vector2 direction, bool isMouse = false)
	{
		padPointer.gameObject.SetActive(!isMouse);
		mousePointer.gameObject.SetActive(isMouse);

		if (isMouse)
		{
			currentPointer = mousePointer;
			//turni
			//var lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			//var lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
			//transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

			currentPointer.position = direction;
		}
		else
		{
			currentPointer = padPointer;
			currentPointer.localPosition = direction * maxPointerDistance;

		}

		lineRenderer.SetPositions(new Vector3[2] { transform.position, currentPointer.position });
		//float dis = Vector3.Distance(pointer.localPosition, direction);


		//(transform.position, Vector3.forward, Vector3.Angle(transform.position, direction));
	}

	public void Move(Vector2 direction)
	{
		Vector3 pos = new Vector3(direction.x * speed, direction.y * speed) + rb.transform.position;
		rb.MovePosition(pos);
	}

	public void Shoot()
	{
		lineRenderer.enabled = true;
		lineRenderer.SetPosition(1, currentPointer.position);
		lineRenderer.SetPositions(new Vector3[2] { transform.position, currentPointer.localPosition });
	}

	public void StopShot()
	{
		lineRenderer.enabled = false;
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
