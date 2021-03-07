using Assets.Scrips.Common.FSM;
using Assets.Scrips.Game.Player;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scripts.Game.Player
{
	public class DamageState: PlayerState
	{
		public DamageState(PlayerController player) : base(PlayerStateType.Damage, player)
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
					Owner.SwitchState(PlayerStateType.Death);
					return;
				}
			}

			Owner.PopState();
		}
	}
}
