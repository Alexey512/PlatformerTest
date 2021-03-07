using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Game.Player;
using Assets.Scripts.Game.Units.Bullet;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game.Units.Enemy
{
	public class EnemyController: UnitController<EnemyModel>
	{
		[Inject]
		private EnemyConfig _config;

		private const float _limitHeight = -5;

		protected override void OnInitialize()
		{
			Model.Health = Random.Range(_config.MinHealth, _config.MaxHealth);

			Owner.UnitCollision += UnitCollision;

			StateMachine.AddState<MoveState>(new []{ this });
			StateMachine.AddState<DeathState>(new []{ this });

			StateMachine.AddTransition(EnemyStateType.Death, EnemyEventType.Damage);

			StateMachine.SetInitialState(EnemyStateType.Move);
		}

		private void UnitCollision(IUnit unit)
		{
			var bullet = unit.GetModel<BulletModel>();
			if (bullet != null)
			{
 				Model.Health -= bullet.Damage;
				if (Model.Health <= 0)
				{
					StateMachine.HandleEvent(EnemyEventType.Damage);
				}
			}
			else
			{
				StateMachine.HandleEvent(EnemyEventType.Damage);
			}
		}

	}
}
