using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.InputSystem;

namespace Assets.Scrips.Game.Player
{
	public class PlayerController
	{
		private IStateMachine _fsm;

		private IInputManager _inputManager;

		public PlayerController(IInputManager inputManager, StateMachineFactory fsm)
		{
			_fsm = fsm.Create();

			_inputManager = inputManager;

			InitializeStates();
		}

		private void InitializeStates()
		{

		}
	}
}
