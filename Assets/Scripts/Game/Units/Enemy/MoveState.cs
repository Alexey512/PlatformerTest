using System;
using Assets.Scrips.Common.FSM;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Game.Units.Enemy
{
	public class MoveState: EnemyState
	{
		public MoveState(EnemyController unit) : base(EnemyStateType.Move, unit)
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
			var velocity = Unit.Owner.Velocity;
			velocity.x = -Random.Range(Unit.Config.MinSpeed, Unit.Config.MaxSpeed);
			Unit.Owner.Velocity = velocity;
		}
	}
}
