﻿using System;
namespace GXPEngine
{
	public class Menu : GameObject
	{
		private Button _button;
		bool _hasStarted;

		public Menu() : base ()
		{
			_hasStarted = false;

			_button = new Button();
			AddChild(_button);
			_button.x = (game.width - _button.width) / 2;
			_button.y = (game.height - _button.height) / 2;
		}

		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (_button.HitTestPoint (Input.mouseX, Input.mouseY))
				{
					StartGame();
					HideMenu();
				}
			}

		}

		public void HideMenu()
		{
			_button.visible = false;
		}

		public void ShowMenu()
		{
			_button.visible = true;
		}

		public void StartGame()
		{
			if (_hasStarted == false)
			{
				MyGame myGame = game as MyGame;
				myGame.CreateLevel();
				myGame.CreateHud();
				_hasStarted = true;
			}
		}
	}
}
