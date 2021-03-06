using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.InputSystem;
using Assets.Scripts.Game.Units;
using Zenject;

namespace Assets.Scrips.Game.Player
{
	public enum PlayerStateType
	{
		Idle,
		Run,
		Jump,
		Shoot
	}
	
	public class PlayerState: UnitState<PlayerController>
	{
		[Inject]
		protected PlayerConfig Config { get; }

		public PlayerState(PlayerStateType state, PlayerController player) : base(state.ToString(), player)
		{
		}
	}
}
