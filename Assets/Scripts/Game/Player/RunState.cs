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
			var velocity = Player.Owner.Velocity;
			
			if (InputManager.GetKey(KeyCode.RightArrow))
			{
				velocity.x = Config.MaxSpeed;
				Player.Owner.Velocity = velocity;
			}
			else if (InputManager.GetKey(KeyCode.LeftArrow))
			{
				velocity.x = Config.MinSpeed;
				Player.Owner.Velocity = velocity;
			}
			else
			{
				velocity.x = Config.Speed;
				Player.Owner.Velocity = velocity;
			}

			if (InputManager.GetKey(KeyCode.UpArrow))
			{
				//Owner.HandleEvent(new Event { Id = "Jump" });
				Owner.SwitchState("Jump");
			}
		}
	}
}
