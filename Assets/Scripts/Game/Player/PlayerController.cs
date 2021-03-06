using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.InputSystem;
using Assets.Scripts.Common.Visual;
using UnityEngine;
using Zenject;

namespace Assets.Scrips.Game.Player
{
	[ViewName("PlayerView")]
	public class PlayerController: IController<PlayerView>
	{
		public PlayerView View { get; set; }

		public Vector2 MoveForce { get; set; }

		public Vector2 Position
		{
			get => View != null ? View.transform.position : Vector3.zero;
			set
			{
				if (View != null)
				{
					View.transform.position = value;
				}
			}
		}

		private IStateMachine _fsm;

		private IInputManager _inputManager;

		//private float _moveForce;

		public PlayerController(IInputManager inputManager, StateMachineFactory fsm)
		{
			_fsm = fsm.Create();

			_inputManager = inputManager;

			InitializeStates();
		}

		public void Update()
		{
			if (_fsm != null)
			{
				_fsm.Update();
			}

			if (View != null)
			{
				View.SetForce(MoveForce);
			}
		}

		private void InitializeStates()
		{
			_fsm.AddState<IdleState>(new []{ this });
			_fsm.AddState<RunState>(new []{ this });

			_fsm.SetInitialState("Idle");

			_fsm.Start();
		}
	}
}
