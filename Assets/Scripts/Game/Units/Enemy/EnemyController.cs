using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.Units.Enemy
{
	public class EnemyController: UnitController<EnemyModel>
	{
		protected override void OnInitialize()
		{
			Owner.UnitCollision += UnitCollision;

			StateMachine.AddState<MoveState>(new []{ this });
			StateMachine.AddState<DeathState>(new []{ this });

			StateMachine.AddTransition(EnemyStateType.Death, EnemyEventType.Damage);

			StateMachine.SetInitialState(EnemyStateType.Move);
		}

		private void UnitCollision(IUnit unit)
		{
			StateMachine.HandleEvent(EnemyEventType.Damage);
		}
	}
}
