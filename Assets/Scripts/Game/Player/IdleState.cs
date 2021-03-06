﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using UnityEngine;

namespace Assets.Scrips.Game.Player
{
	public class IdleState: PlayerState
	{
		public IdleState(PlayerController owner) : base("Idle", owner)
		{
		}

		public override void Enter(State prevState)
		{
			Owner.SwitchState("Run");
		}

		public override void Update()
		{
		}
	}
}
