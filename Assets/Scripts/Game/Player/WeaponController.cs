using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Game.Player;
using UnityEngine;

namespace Assets.Scripts.Game.Player
{
	public class WeaponController
	{
		private PlayerConfig _config;

		private float _timeToShoot;

		public WeaponController(PlayerConfig config)
		{
			_config = config;
		}

		public bool TryShoot()
		{
			if (_timeToShoot <= 0)
			{
				_timeToShoot = _config.RoF;
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
