using Assets.Scripts.Game.Player;
using Assets.Scripts.Game.Units;
using Zenject;

namespace Assets.Scrips.Game.Player
{
	public enum PlayerStateType
	{
		Idle,
		Run,
		Jump,
		Damage,
		Shoot,
		Death
	}

	public enum PlayerEventType
	{
		Jump,
		Damage,
		Shoot,
		Death
	}

	public class PlayerState: UnitState<PlayerController, PlayerModel>
	{
		[Inject]
		protected PlayerConfig Config { get; }

		public PlayerState(PlayerStateType state, PlayerController player) : base(state.ToString(), player)
		{
		}
	}
}
