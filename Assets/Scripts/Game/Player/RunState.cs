using Assets.Scrips.Common.FSM;
using UnityEngine;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scrips.Game.Player
{
	public class RunState: PlayerState
	{
		public RunState(PlayerController owner) : base(PlayerStateType.Run, owner)
		{
		}

		public override void Enter(State prevState, EventArgs args = null)
		{
			Unit.Animator.SetBool("IsMove", true);
		}

		public override void Update()
		{
			var kinematicObject = Unit.Owner;
			var velocity = kinematicObject.Velocity;
			
			if (InputManager.GetKey(KeyCode.RightArrow))
			{
				velocity.x = Config.MaxSpeed;
				kinematicObject.Velocity = velocity;
			}
			else if (InputManager.GetKey(KeyCode.LeftArrow))
			{
				velocity.x = Config.MinSpeed;
				kinematicObject.Velocity = velocity;
			}
			else
			{
				velocity.x = Config.Speed;
				kinematicObject.Velocity = velocity;
			}

			if (InputManager.GetKey(KeyCode.UpArrow))
			{
				Owner.HandleEvent(PlayerEventType.Jump);
			}
		}
	}
}
