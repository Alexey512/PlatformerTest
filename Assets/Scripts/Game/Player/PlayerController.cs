using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.InputSystem;
using Assets.Scripts.Common.Visual;
using Assets.Scripts.Game.Units;
using UnityEngine;
using Zenject;

namespace Assets.Scrips.Game.Player
{
	public class PlayerController: MonoBehaviour
	{
		public KinematicObject Owner => _owner;

		[SerializeField]
		private KinematicObject _owner;

		private IStateMachine _fsm;

		[Inject]
		private void Construct(StateMachineFactory fsm)
		{
			_fsm = fsm.Create();

			InitializeStates();
		}

		public void Update()
		{
			if (_fsm != null)
			{
				_fsm.Update();
			}
		}

		private void InitializeStates()
		{
			_fsm.AddState<IdleState>(new []{ this });
			_fsm.AddState<RunState>(new []{ this });
			_fsm.AddState<JumpState>(new []{ this });

			_fsm.SetInitialState("Idle");

			_fsm.Start();
		}
	}
}
