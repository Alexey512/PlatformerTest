using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.InputSystem;
using Assets.Scripts.Common.Visual;
using Assets.Scripts.Game.Player;
using Assets.Scripts.Game.Units;
using Assets.Scripts.Game.Units.Enemy;
using UnityEngine;
using Zenject;
using DeathState = Assets.Scripts.Game.Player.DeathState;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scrips.Game.Player
{
	public class PlayerController: UnitController<PlayerModel>
	{
		public event Action<float> Damage; 

		public event Action Death;
		
		[Inject]
		private IInputManager _inputManager;

		[Inject]
		private PlayerConfig _config;

		private WeaponController _weaponController;

		protected override void OnInitialize()
		{
			_weaponController = new WeaponController(_config);
			
			Model.Health = _config.MaxHealth;

			Owner.UnitCollision += UnitCollision;
			
			StateMachine.ChangeState += OnChangeState;

			StateMachine.AddState<IdleState>(new []{ this });
			StateMachine.AddState<RunState>(new []{ this });
			StateMachine.AddState<JumpState>(new []{ this });
			StateMachine.AddState<DamageState>(new []{ this });
			StateMachine.AddState<ShootState>(new []{ this });
			StateMachine.AddState<DeathState>(new []{ this });

			StateMachine.AddTransition(PlayerStateType.Damage, PlayerEventType.Damage);
			StateMachine.AddTransition(PlayerStateType.Shoot, PlayerEventType.Shoot);
			StateMachine.AddTransition(PlayerStateType.Death, PlayerEventType.Death);

			StateMachine.SetInitialState(PlayerStateType.Idle);
		}

		private void OnChangeState(State state, State prevState)
		{
			if (state.Name == PlayerStateType.Death.ToString())
			{
				Death?.Invoke();
			}
		}

		private void UnitCollision(IUnit unit)
		{
			var enemyModel = unit.GetModel<EnemyModel>();
			if (enemyModel != null)
			{
				var data = new EventArgs();
				data.SetValue("Damage", enemyModel.Damage);

				StateMachine.HandleEvent(PlayerEventType.Damage);

				Damage?.Invoke(enemyModel.Damage);
			}
		}

		private void UpdateHealth()
		{
			if (Model.Health <= 0)
			{
				StateMachine.HandleEvent(PlayerEventType.Death);
			}
		}

		private void UpdateWeapon()
		{
			if (_weaponController == null)
			{
				return;
			}
			
			_weaponController.Update();
			
			if (_inputManager.GetKey(KeyCode.Space))
			{
				if (_weaponController.TryShoot())
				{
					StateMachine.HandleEvent(PlayerEventType.Shoot);
				}
			}
		}

		protected override void OnUpdate()
		{
			UpdateWeapon();
			UpdateHealth();
		}
	}
}
