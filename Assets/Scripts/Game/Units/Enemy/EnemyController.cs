using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.Units.Enemy
{
	public class EnemyController: UnitController
	{
		protected override void OnInitialize()
		{
			StateMachine.AddState<MoveState>(new []{ this });

			StateMachine.SetInitialState(EnemyStateType.Move);
		}
	}
}
