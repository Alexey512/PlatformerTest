using Assets.Scrips.Common.FSM;
using UnityEngine;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scrips.Game.Player
{
	public class IdleState: PlayerState
	{
		public IdleState(PlayerController owner) : base(PlayerStateType.Idle, owner)
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
		}

		public override void Update()
		{
		}
	}
}
