using Assets.Scrips.Common.FSM;
using UnityEngine;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scrips.Game.Player
{
	public class JumpState: PlayerState
	{
		public JumpState(PlayerController player) : base(PlayerStateType.Jump, player)
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
			if (Unit.Owner.IsGrounded)
			{
				Unit.Owner.Velocity = new Vector2(Unit.Owner.Velocity.x, Config.JumpHeight);

				Unit.Animator.SetTrigger("IsJump");
			}

			Owner.PopState();
		}
	}
}
