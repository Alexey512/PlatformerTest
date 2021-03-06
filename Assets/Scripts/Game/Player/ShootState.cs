﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.Visual;
using Assets.Scripts.Game.Units.Bullet;
using Zenject;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scrips.Game.Player
{
	public class ShootState: PlayerState
	{
		[Inject]
		private IPrefabsFactory _factory;

		public ShootState(PlayerController player) : base(PlayerStateType.Shoot, player)
		{
		}

		public override void Enter(State prevState, EventArgs args = null)
		{
			var bullet = _factory.Create<BulletController>(Config.WeaponId);
			if (bullet != null)
			{
				bullet.StartMove();
				bullet.transform.position = Unit.transform.position;
			}

			Owner.PopState();
		}
	}
}
