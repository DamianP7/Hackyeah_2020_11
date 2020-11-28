using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	private static CharacterController player;
	public static CharacterController Player
	{
		get
		{
			if (player == null)
				player = FindObjectOfType<CharacterController>();
			return player;
		}
	}


	[Header("Pointer")]
	public LineRenderer lineRenderer;
	public Material lineMaterial;
	public Transform padPointer;
	public Transform mousePointer;
	public float maxPointerDistance;

	[Header("Guns")]
	public Gun[] guns;
	public Gun selectedGun;
	[HideInInspector]
	public bool shooting = false;
	int gunIndex = 0;

	[Header("Stats")]
	private int points = 0;
	public int Points
	{
		get => points;
		set
		{
			points = value;
			LevelManager.Instance.points.text = points.ToString();
		}
	}
	[SerializeField] float speed = 1;


	int hp = 100;
	Rigidbody2D rb;
	Transform currentPointer;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		SetWeapon(0);
	}

	private void Start()
	{
		lineRenderer.enabled = false;
		Points = 0;
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
		shooting = true;
		lineRenderer.enabled = true;
		lineRenderer.SetPosition(1, currentPointer.position);
		lineRenderer.SetPositions(new Vector3[2] { transform.position, currentPointer.localPosition });
	}

	public void StopShot()
	{
		shooting = false;
		lineRenderer.enabled = false;
	}

	public void ChangeWeapon(int changeDirection)
	{
		if (changeDirection < 0)
		{
			if (gunIndex > 0)
				gunIndex--;
			else
				gunIndex = guns.Length - 1;
		}
		else
		{
			if (gunIndex < guns.Length - 1)
				gunIndex++;
			else
				gunIndex = 0;
		}

		SetWeapon(gunIndex);
	}

	public void SetWeapon(int index)
	{
		if (index < 0)
			index = 0;
		else if (index >= guns.Length)
			index = guns.Length - 1;

		selectedGun = guns[gunIndex];

		lineMaterial.SetColor("Color_799E5E3C", selectedGun.color);
		lineMaterial.SetFloat("Vector1_C8425888", selectedGun.width);
		lineMaterial.SetFloat("Vector1_D61737C7", selectedGun.distortion);
		lineMaterial.SetVector("Vector2_763B5D71", new Vector4(selectedGun.speed, selectedGun.frequency, 0, 0));
		lineMaterial.SetFloat("Vector1_52AC407D", selectedGun.noiseScale);
	}
}
