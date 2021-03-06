﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using UnityEngine;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scripts.Game.Units.Enemy
{
	public class DeathState: EnemyState
	{
		public DeathState(EnemyController unit) : base(EnemyStateType.Death, unit)
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
			GameObject.Destroy(Unit.gameObject);
		}
	}
}