using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.Visual;
using Assets.Scrips.Game.Player;
using Zenject;

namespace Assets.Scripts.Game.Player
{
	public class DeathState: PlayerState
	{
		[Inject]
		private IPrefabsFactory _factory;
		
		public DeathState(PlayerController unit) : base(PlayerStateType.Death, unit)
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
			_factory.Remove(Unit.gameObject, true);
		}
	}
}
