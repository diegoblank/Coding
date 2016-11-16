﻿using System;
namespace GXPEngine
{
	public class Player : Sprite
	{

		public static float PlayerPosX;

		private float _LastY;
		private int _timer;
		private int _crouchTimer;

		private float _gravity;
		private bool _canJump;

		private float speedX;
		private float speedY;

		private int state; 

		public Player() : base ("player.png")
		{
			state = 1;
			_crouchTimer = 0;

			SetOrigin(width / 2, height);
			x = 400;
			y = 300;
			_LastY = 0;
			_timer = 0;

			_gravity = 1.05f;
			_canJump = true;

			speedX = 1.0f;
			speedY = 0.95f;

			scaleX = scaleX * 0.2f;
			scaleY = scaleY * 0.2f;
		}

		void Update() 
		{



			PlayerPosX = this.x;

			_timer = _timer - 1;
			_crouchTimer = _crouchTimer - 1;

			if (_timer <= 0)
			{

				_timer = 0;

			}

			if (_crouchTimer <= 0) 
			{
				_crouchTimer = 0;
				scaleY = 0.2f;
			}

			if (Input.GetKey(Key.D))
				{
					speedX = speedX + 2;
					state = 1;
					Mirror(true, false);
					
				}

			if (Input.GetKeyDown(Key.S) && _crouchTimer == 0)
			{
				
				state = 4;
				scaleY = scaleY *(0.5f);
				_crouchTimer = 50;

			}

			if (Input.GetKey(Key.A))
				{
					speedX = speedX - 2;
					state = 2;
					Mirror(false, false);
				}

			if (Input.GetKeyDown(Key.SPACE) && _canJump == true)
				{
					speedY = speedY - 80;
					_canJump = false;
					_timer = 20;
					state = 3;
				}


				if (Input.GetKey(Key.SPACE) && _timer >= 0)
				{
					speedY = speedY * 1.1f;

				}

				

				speedX = speedX * 0.8f; 
				speedY = speedY * 0.8f;

				_LastY = y;

				y = y + speedY;
				x = x + speedX;

				y = y * _gravity;


				Console.WriteLine(state);

		}



		public void OnCollision(GameObject other)
		{
			if (other is BaseLongCargo)
			{

				BaseLongCargo baselongcargo = other as BaseLongCargo;

				if (y >= baselongcargo.y)
				{
					y = baselongcargo.y;

				}

				if (_timer == 0) 
				{
					_canJump = true;
				}

			}

			if (other is BaseLong)
			{
				BaseLong baselong = other as BaseLong;

				if (y >= baselong.y) 
				{
					y = baselong.y;
				
				}

				_canJump = false;

			}

			if (other is BaseCeiling)
			{
				BaseCeiling baseceiling = other as BaseCeiling;

				if (y >= baseceiling.y)
				{
					y = baseceiling.y;

				}

				if (_timer == 0)
				{
					_canJump = true;
				}

			}

			if (other is BaseShort)
			{

				BaseShort wagon3 = other as BaseShort;

				if (y >= wagon3.y)
				{
					y = wagon3.y;

				}

				if (_timer == 0)
				{
					_canJump = true;
				}

			}

			if (other is BaseIntermediateCargo)
			{

				BaseIntermediateCargo baseintermediatecargo = other as BaseIntermediateCargo;

				if (y >= baseintermediatecargo.y)
				{
					y = baseintermediatecargo.y;

				}

				if (_timer == 0)
				{
					_canJump = true;
				}

			}

			if (other is BaseIntermediate)
			{

				BaseIntermediate baseintermediate = other as BaseIntermediate;

				if (y >= baseintermediate.y)
				{
					y = baseintermediate.y;

				}

				_canJump = false;

			}

			if (other is BaseIntermediateCeiling)
			{

				BaseIntermediateCeiling baseintermediateceiling = other as BaseIntermediateCeiling;

				if (y >= baseintermediateceiling.y)
				{
					y = baseintermediateceiling.y;

				}

				if (_timer == 0)
				{
					_canJump = true;
				}

			}

			if (other is LongBackgroundLocomotive)
			{

				LongBackgroundLocomotive longbackgroundfront = other as LongBackgroundLocomotive;

				if (y >= longbackgroundfront.y)
				{
					y = longbackgroundfront.y;

				}

				if (_timer == 0)
				{
					_canJump = true;
				}

			}


			if (other is Crate)
			{

				Crate crate = other as Crate;


				if (x > crate.x + 80) 
				{
					x = crate.x + 100;
				}

				if (x <= crate.x) 
				{
					x = crate.x-20;
				}

				if (_timer == 0)
				{
					_canJump = true;
				}

			}



		}
	}
}
