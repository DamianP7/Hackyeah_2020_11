using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlManager : MonoBehaviour
{
	public CharacterController player;


	bool left, right, up, down;
	bool gamepadInput;

	public enum Control
	{
		PC,
		Controller,
		Mobile
	}

#if UNITY_ANDROID
	Control controls = Control.Mobile;
#else
	public Control controls = Control.Controller;
#endif

	void Update()
	{
		if (controls == Control.Mobile)
			return;
		else if (Gamepad.current != null && controls == Control.Controller)
			HandleGamepad();
		else if (controls == Control.PC)
			HandlePC();
	}

	void HandleGamepad()
	{
		var gamepad = Gamepad.current;
		if (gamepad == null)
			return; // No gamepad connected.

		if (gamepad.rightTrigger.wasPressedThisFrame)
		{
			// TODO: full auto fire
			player.Shoot();
		}
		if (gamepad.rightShoulder.wasPressedThisFrame)
		{
			//player.NextWeapon();
		}
		if (gamepad.leftShoulder.wasPressedThisFrame)
		{
			//player.PreviousWeapon();
		}

		player.Aim(gamepad.rightStick.ReadValue());

		player.Move(gamepad.leftStick.ReadValue());
	}

	void HandlePC()
	{
		if (Mouse.current.leftButton.wasPressedThisFrame)
		{
			player.Shoot();
		}
		//if (Mouse.current.scroll.)
		//{
		//	//player.NextWeapon();
		//}
		//if (gamepad.leftShoulder.wasPressedThisFrame)
		//{
		//	//player.PreviousWeapon();
		//}
		player.Aim(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()),true);


		if (Keyboard.current.leftArrowKey.wasPressedThisFrame || Keyboard.current.aKey.wasPressedThisFrame)
			left = true;
		else if (Keyboard.current.leftArrowKey.wasReleasedThisFrame || Keyboard.current.aKey.wasReleasedThisFrame)
			left = false;

		if (Keyboard.current.rightArrowKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame)
			right = true;
		else if (Keyboard.current.rightArrowKey.wasReleasedThisFrame || Keyboard.current.dKey.wasReleasedThisFrame)
			right = false;

		if (Keyboard.current.upArrowKey.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame)
			up = true;
		else if (Keyboard.current.upArrowKey.wasReleasedThisFrame || Keyboard.current.wKey.wasReleasedThisFrame)
			up = false;

		if (Keyboard.current.downArrowKey.wasPressedThisFrame || Keyboard.current.sKey.wasPressedThisFrame)
			down = true;
		else if (Keyboard.current.downArrowKey.wasReleasedThisFrame || Keyboard.current.sKey.wasReleasedThisFrame)
			down = false;

		Vector2 direction = Vector2.zero;
		if (up)
			direction.y += 1;
		if (down)
			direction.y -= 1;
		if (left)
			direction.x -= 1;
		if (right)
			direction.x += 1;

		player.Move(direction);
	}


}
