using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Pointer : MonoBehaviour
{
	public CharacterController player;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (!player.shooting)
			return;
		if (collision.gameObject.CompareTag(Tags.trash))
		{
			collision.gameObject.GetComponent<Trash>().Hitted(player.selectedGun.beamType, player.selectedGun.force);
		}
	}
}
