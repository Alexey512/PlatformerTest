using Assets.Scrips.Common.FSM;
using Assets.Scrips.Game.Player;
using UnityEngine;

namespace Assets.Scripts.Game.Player
{
	public class WeaponController
	{
		private readonly PlayerConfig _config;

		private readonly IStateMachine _stateMachine;

		private float _timeToShoot;

		public WeaponController(PlayerConfig config, IStateMachine stateMachine)
		{
			_config = config;
			_stateMachine = stateMachine;
		}

		public bool TryShoot()
		{
			if (_timeToShoot <= 0)
			{
				_timeToShoot = _config.RoF;
				
				_stateMachine.HandleEvent(PlayerEventType.Shoot);
				
				return true;
			}

			return false;
		}

		public void Update()
		{
			if (_timeToShoot > 0)
			{
				_timeToShoot -= Time.deltaTime;
			}
		}
	}
}
