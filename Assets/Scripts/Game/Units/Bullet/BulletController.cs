using Assets.Scripts.Game.Player;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game.Units.Bullet
{
	public class BulletController : UnitController<BulletModel>
	{
		[Inject] private PlayerCamera _camera;

		[Inject] private BulletConfig _config;

		protected override void OnInitialize()
		{
			Model.Damage = _config.Damage;

			Owner.UnitCollision += UnitCollision;

			StateMachine.AddState<FlyState>(new[] {this});
			StateMachine.AddState<ExplosionState>(new[] {this});

			StateMachine.AddTransition(BulletStateType.Explosion, BulletEventType.Explosion);

			StateMachine.SetInitialState(BulletStateType.Fly);
		}

		protected override void OnUpdate()
		{
			var camera = _camera.Camera;
			if (camera == null) return;

			var halfHeight = camera.orthographicSize;
			var halfWidth = camera.aspect * halfHeight;

			Vector2 camPos = _camera.transform.position;

			var camRight = camPos.x + halfWidth;

			if (Owner.Position.x > camRight) StateMachine.SwitchState(BulletStateType.Explosion);
		}

		private void UnitCollision(IUnit unit)
		{
			StateMachine.HandleEvent(BulletEventType.Explosion);
		}
	}
}