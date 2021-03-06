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


		public RunState(PlayerController owner) : base("Run", owner)
		{
		}

		public override void Update()
		{
			var force = Player.MoveForce;

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
		}
	}
}
