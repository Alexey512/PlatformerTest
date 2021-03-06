using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Game.Units.Enemy
{
	public class MoveState: EnemyState
	{
		public MoveState(EnemyController unit) : base(EnemyStateType.Move, unit)
		{
		}

		public override void Enter(State prevState)
		{
			var velocity = Unit.Owner.Velocity;
			velocity.x = -Random.Range(Config.MinSpeed, Config.MaxSpeed);
			Unit.Owner.Velocity = velocity;
		}


	}
}
