using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scripts.Game.Player;
using UnityEngine;
using Zenject;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Game.Units.Enemy
{
	public class MoveState: EnemyState
	{
		//[Inject]
		//private PlayerCamera _camera;
		
		public MoveState(EnemyController unit) : base(EnemyStateType.Move, unit)
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
			var velocity = Unit.Owner.Velocity;
			velocity.x = -Random.Range(Unit.Config.MinSpeed, Unit.Config.MaxSpeed);
			Unit.Owner.Velocity = velocity;
		}

		/*
		public override void Update()
		{
			var camera = _camera.Camera;
			float halfHeight = camera.orthographicSize;
			float halfWidth = camera.aspect * halfHeight;
			float camLeft = _camera.transform.position.x - halfWidth * 2;

			if (Unit.Owner.Position.x < camLeft)
			{
				Owner.SwitchState(EnemyStateType.Death);
			}
		}*/
	}
}
