using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.InputSystem;
using UnityEngine;

namespace Assets.Scrips.Game.Player
{
	public class RunState: PlayerState
	{
		public float maxSpeed = 3.4f;
		public float jumpHeight = 6.5f;
		public float gravityScale = 1.5f;

		bool facingRight = true;
		float moveDirection = 0;
		bool isGrounded = false;

		public RunState(PlayerController owner) : base("Run", owner)
		{
		}

		public override void Update()
		{
			
			//_body.velocity = new Vector2((moveDirection) * Speed, _body.velocity.y);

			var velocity = Player.Owner.Velocity;
			
			if (InputManager.GetKey(KeyCode.RightArrow))
			{
				//velocity.x += Config.Acceleration * Time.deltaTime;
				//velocity.x = Math.Min(velocity.x, Config.MaxSpeed);
				velocity.x = Config.MaxSpeed;
				Player.Owner.Velocity = velocity;

				//Player.Owner.Speed = Mathf.Lerp(Player.Owner.Speed, Config.MaxSpeed, Time.deltaTime);
				//force.x = Mathf.Min(force.x + Config.Acceleration * Time.deltaTime, Config.MaxSpeed);
			}
			else if (InputManager.GetKey(KeyCode.LeftArrow))
			{
				//velocity.x -= Config.Acceleration * Time.deltaTime;
				//velocity.x = Math.Max(velocity.x, Config.MinSpeed);
				velocity.x = Config.MinSpeed;
				Player.Owner.Velocity = velocity;

				//Player.Owner.Speed = Mathf.Lerp(Player.Owner.Speed, Config.MinSpeed, Time.deltaTime);
				//force.x = Mathf.Max(force.x - Config.Acceleration * Time.deltaTime, Config.MinSpeed);
			}
			else
			{
				//Player.Owner.Speed = Mathf.Lerp(Player.Owner.Speed, Config.Speed, Time.deltaTime);

				velocity.x = Config.Speed;
				Player.Owner.Velocity = velocity;
			}

			if (InputManager.GetKey(KeyCode.UpArrow))
			{
				//Owner.HandleEvent(new Event { Id = "Jump" });
				Owner.SwitchState("Jump");
			}
		}

		/*public void Update_()
		{
			//var force = Player.MoveForce;
			var force = Vector2.zero;

			float h = Input.GetAxis("Horizontal");

			if (h * Player.Velocity.x < Config.MaxSpeed)
			{
				force = Vector2.right * h * Config.MoveForce;
			}

			if (InputManager.GetKey(KeyCode.RightArrow))
			{
				force.x = Mathf.Min(force.x + Config.Acceleration * Time.deltaTime, Config.MaxSpeed);
			}
			else if (InputManager.GetKey(KeyCode.LeftArrow))
			{
				force.x = Mathf.Max(force.x - Config.Acceleration * Time.deltaTime, Config.MinSpeed);
			}
			else if (InputManager.GetKey(KeyCode.UpArrow))
			{
				//Owner.HandleEvent(new Event { Id = "Jump" });
				Owner.SwitchState("Jump");
			}
			else
			{
				
			}

			Player.MoveForce = force;
		}*/
	}
}
