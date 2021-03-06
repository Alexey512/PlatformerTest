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
	public class PlayerController: UnitController
	{
		protected override void OnInitialize()
		{
			StateMachine.AddState<IdleState>(new []{ this });
			StateMachine.AddState<RunState>(new []{ this });
			StateMachine.AddState<JumpState>(new []{ this });

			StateMachine.SetInitialState(PlayerStateType.Idle);
		}
	}
}
