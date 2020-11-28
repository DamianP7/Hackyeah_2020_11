﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlManager : MonoBehaviour
{
	public enum InputState
	{
		Game,
		Loading
	}

	public CharacterController player;
	public float minScroll = 10;

	public InputState inputState = InputState.Game;

	bool left, right, up, down;
	bool gamepadInput;
	bool shooting = false;

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
		switch (inputState)
		{
			case InputState.Game:
				if (controls == Control.Mobile)
					return;
				else if (Gamepad.current != null && controls == Control.Controller)
					HandleGamepad();
				else
					HandlePC();

				if (Mouse.current.rightButton.wasPressedThisFrame)
				{
					LoadingScreen.Instance.LoadScene("SampleScene");
				}
				break;
			case InputState.Loading:
				if (Keyboard.current.anyKey.wasPressedThisFrame)
					LoadingScreen.Instance.OnClickContinue();
				break;
		}
	}

	void HandleGamepad()
	{
		var gamepad = Gamepad.current;
		if (gamepad == null)
			return; // No gamepad connected.

		player.Aim(gamepad.rightStick.ReadValue());
		player.Move(gamepad.leftStick.ReadValue());

		if (gamepad.rightTrigger.wasPressedThisFrame)
		{
			player.Shoot();
		}
		else if (gamepad.rightTrigger.wasReleasedThisFrame)
		{
			player.StopShot();
		}
		if (gamepad.rightShoulder.wasPressedThisFrame)
		{
			player.ChangeWeapon(1);
		}
		if (gamepad.leftShoulder.wasPressedThisFrame)
		{
			player.ChangeWeapon(-1);
		}

	}

	void HandlePC()
	{
		player.Aim(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()),true);

		if (Mouse.current.leftButton.wasPressedThisFrame)
		{
			player.Shoot();
		}
		else if (Mouse.current.leftButton.wasReleasedThisFrame)
		{
			player.StopShot();
		}
		if (/*Mouse.current.scroll.ReadValue().x > minScroll || */Keyboard.current.eKey.wasPressedThisFrame)
		{
			player.ChangeWeapon(1);
		}
		if (/*Mouse.current.scroll.ReadValue().x < minScroll || */Keyboard.current.qKey.wasPressedThisFrame)
		{
			player.ChangeWeapon(-1);
		}
		if(Keyboard.current.digit1Key.wasPressedThisFrame)
		{
			player.SetWeapon(0);
		}
		if (Keyboard.current.digit2Key.wasPressedThisFrame)
		{
			player.SetWeapon(1);
		}
		if (Keyboard.current.digit3Key.wasPressedThisFrame)
		{
			player.SetWeapon(2);
		}


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