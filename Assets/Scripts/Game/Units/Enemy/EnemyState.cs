﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Game.Units.Enemy
{
	public enum EnemyStateType
	{
		Idle,
		Move,
		Death,
	}	
	
	public class EnemyState: UnitState<EnemyController>
	{
		[Inject]
		protected EnemyConfig Config { get; }

		public EnemyState(EnemyStateType state, EnemyController unit) : base(state.ToString(), unit)
		{
		}
	}
}