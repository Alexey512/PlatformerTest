using System;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.InputSystem;
using Assets.Scripts.Game.Player;
using Assets.Scripts.Game.Units;
using UnityEngine;
using Zenject;
using DamageState = Assets.Scripts.Game.Player.DamageState;
using DeathState = Assets.Scripts.Game.Player.DeathState;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scrips.Game.Player
{
	public class PlayerController: UnitController<PlayerModel>
	{
		public event Action<float> Damage; 

		public event Action Death;

		public Animator Animator => _animator;

		[SerializeField]
		private Animator _animator;

		[Inject]
		private IInputManager _inputManager;

		[Inject]
		private PlayerConfig _config;

		private WeaponController _weaponController;

		public void ResetParams()
		{
			Model.Health = _config.MaxHealth;
		}

		protected override void OnInitialize()
		{
			_weaponController = new WeaponController(_config, StateMachine);

			ResetParams();

			Owner.UnitCollision += UnitCollision;
			
			StateMachine.ChangeState += OnChangeState;

			StateMachine.AddState<IdleState>(new []{ this });
			StateMachine.AddState<RunState>(new []{ this })
				.AddTransition(PlayerStateType.Jump, PlayerEventType.Jump)
				.AddTransition(PlayerStateType.Damage, PlayerEventType.Damage);
			StateMachine.AddState<JumpState>(new[] {this})
				.AddTransition(PlayerStateType.Damage, PlayerEventType.Damage);
			StateMachine.AddState<DamageState>(new []{ this });
			StateMachine.AddState<ShootState>(new []{ this });
			StateMachine.AddState<DeathState>(new []{ this });

			StateMachine.AddTransition(PlayerStateType.Shoot, PlayerEventType.Shoot);
			StateMachine.AddTransition(PlayerStateType.Death, PlayerEventType.Death);

			StateMachine.SetInitialState(PlayerStateType.Run);
		}

		protected override void OnUpdate()
		{
			UpdateWeapon();
		}

		private void OnChangeState(State state, State prevState)
		{
			if (state.Name == PlayerStateType.Idle.ToString())
			{
				Death?.Invoke();
			}
		}

		private void UnitCollision(IUnit unit)
		{
			var enemyModel = unit.GetModel<Assets.Scripts.Game.Units.Enemy.EnemyModel>();
			if (enemyModel != null)
			{
				var data = new EventArgs();
				data.SetValue("Damage", enemyModel.Damage);

				StateMachine.HandleEvent(PlayerEventType.Damage, data);

				Damage?.Invoke(enemyModel.Damage);
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
				_weaponController.TryShoot();
			}
		}
	}
}
