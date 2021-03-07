using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Game.Player;
using Assets.Scripts.Game.Units.Enemy;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game.Units.Bullet
{
	public class BulletController: UnitController<BulletModel>
	{
		[Inject]
		private BulletConfig _config;

		[Inject]
		private PlayerCamera _camera;

		protected override void OnInitialize()
		{
			Model.Damage = _config.Damage;
			
			Owner.UnitCollision += UnitCollision;

			StateMachine.AddState<FlyState>(new []{ this });
			StateMachine.AddState<ExplosionState>(new []{ this });

			StateMachine.AddTransition(BulletStateType.Explosion, BulletEventType.Explosion);

			StateMachine.SetInitialState(BulletStateType.Fly);
		}

		private void UnitCollision(IUnit unit)
		{
			StateMachine.HandleEvent(BulletEventType.Explosion);
		}

		
		protected override void OnUpdate()
		{
			var camera = _camera.Camera;
			if (camera == null)
			{
				return;
			}

			float halfHeight = camera.orthographicSize;
			float halfWidth = camera.aspect * halfHeight;

			Vector2 camPos = _camera.transform.position;

			float camRight = camPos.x + halfWidth;

			if (Owner.Position.x > camRight)
			{
				StateMachine.SwitchState(BulletStateType.Explosion);
			}
		}
	}
}
