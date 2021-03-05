using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.InputSystem;
using UnityEngine;
using Zenject;

namespace Assets.Scrips.Game.Player
{
	public class PlayerController: MonoBehaviour
	{
		private PlayerView _view;

		private IStateMachine _fsm;

		private IInputManager _inputManager;

		private Vector2 _moveDirection = Vector2.zero;



		[Inject]
		private void Construct(IInputManager inputManager, StateMachineFactory fsm)
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
