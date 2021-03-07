using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scripts.Game.Player;
using Assets.Scripts.Game.Units.Bullet;
using TMPro;
using UnityEngine;
using Zenject;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Game.Units.Enemy
{
	public class EnemyController: UnitController<EnemyModel>
	{
		public event Action<EnemyController> Death;
		
		public EnemyConfigs.Config Config => _config;

		private EnemyConfigs.Config _config;

		[SerializeField]
		private TextMeshPro _halthLabel;

		public void SetConfig(EnemyConfigs.Config config)
		{
			_config = config;
			ResetParams();
		}
		protected override void OnInitialize()
		{
			ResetParams();

			Owner.UnitCollision += UnitCollision;

			StateMachine.AddState<MoveState>(new []{ this });
			StateMachine.AddState<DamageState>(new []{ this });
			StateMachine.AddState<DeathState>(new []{ this });

			StateMachine.AddTransition(EnemyStateType.Damage, EnemyEventType.Damage);

			StateMachine.SetInitialState(EnemyStateType.Move);
		}

		private void ResetParams()
		{
			if (_config == null)
			{
				return;
			}

			Model.Health = Random.Range(_config.MinHealth, _config.MaxHealth);
			Model.Damage = Random.Range(_config.MinDamage, _config.MaxDamage);
		}

		private void OnChangeState(State state, State prevState)
		{
			if (state.Name == EnemyStateType.Death.ToString())
			{
				Death?.Invoke(this);
			}
		}

		private void UnitCollision(IUnit unit)
		{
   			var bullet = unit.GetModel<BulletModel>();
			if (bullet != null)
			{
				var data = new EventArgs();
				data.SetValue("Damage", bullet.Damage);

				StateMachine.HandleEvent(EnemyEventType.Damage, data);
			}
			else
			{
				var player = unit.GetModel<PlayerModel>();
				if (player != null)
				{
					StateMachine.SwitchState(EnemyStateType.Death);
				}
			}
		}

		private void UpdateHealth()
		{
			if (_halthLabel == null)
			{
				return;
			}

			_halthLabel.text = $"{Mathf.FloorToInt(Model.Health)}";
		}

		protected override void OnUpdate()
		{
			UpdateHealth();
		}
	}
}
