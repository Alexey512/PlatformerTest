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
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scrips.Game.Player
{
	public class PlayerController: UnitController<PlayerModel>
	{
		[Inject]
		private IInputManager _inputManager;

		[Inject]
		private PlayerConfig _config;

		private WeaponController _weaponController;

		protected override void OnInitialize()
		{
			_weaponController = new WeaponController(_config);
			
			Owner.UnitCollision += UnitCollision;
			
			StateMachine.AddState<IdleState>(new []{ this });
			StateMachine.AddState<RunState>(new []{ this });
			StateMachine.AddState<JumpState>(new []{ this });
			StateMachine.AddState<DamageState>(new []{ this });
			StateMachine.AddState<ShootState>(new []{ this });

			StateMachine.AddTransition(PlayerStateType.Damage, PlayerEventType.Damage);
			StateMachine.AddTransition(PlayerStateType.Shoot, PlayerEventType.Shoot);

			StateMachine.SetInitialState(PlayerStateType.Idle);
		}

		private void UnitCollision(IUnit unit)
		{
			var enemyModel = unit.GetModel<EnemyModel>();
			if (enemyModel != null)
			{
				var data = new EventArgs();
				data.SetValue("Damage", enemyModel.Damage);

				StateMachine.HandleEvent(PlayerEventType.Damage);
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
		}
	}
}
