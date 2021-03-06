using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.InputSystem;
using Zenject;

namespace Assets.Scrips.Game.Player
{
	public class PlayerState: State
	{
		protected PlayerController Player { get; }
		
		[Inject]
		protected IInputManager InputManager { get; }

		[Inject]
		protected PlayerConfig Config { get; }

		public PlayerState(string name, PlayerController player) : base(name)
		{
			Player = player;
		}
	}
}
