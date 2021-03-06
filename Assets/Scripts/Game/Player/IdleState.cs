﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using UnityEngine;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scrips.Game.Player
{
	public class IdleState: PlayerState
	{
		public IdleState(PlayerController owner) : base(PlayerStateType.Idle, owner)
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
			Owner.SwitchState(PlayerStateType.Run);
		}

		public override void Update()
		{
		}
	}
}
