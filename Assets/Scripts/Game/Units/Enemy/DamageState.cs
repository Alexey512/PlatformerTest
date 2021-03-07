using Assets.Scrips.Common.FSM;

namespace Assets.Scripts.Game.Units.Enemy
{
	public class DamageState: EnemyState
	{
		public DamageState(EnemyController player) : base(EnemyStateType.Damage, player)
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
			if (args != null)
			{
				float damage = args.GetValue<float>("Damage");

				Unit.Model.Health -= damage;
				if (Unit.Model.Health <= 0)
				{
					Owner.SwitchState(EnemyStateType.Death);
					return;
				}
			}

			Owner.PopState();
		}
	}
}
