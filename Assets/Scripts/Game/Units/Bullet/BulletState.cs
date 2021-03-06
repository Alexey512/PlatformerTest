using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Game.Units.Enemy;
using Zenject;

namespace Assets.Scripts.Game.Units.Bullet
{
	public enum BulletStateType
	{
		Fly,
		Explosion,
	}

	public enum BulletEventType
	{
		Explosion
	}

	public class BulletState: UnitState<BulletController, BulletModel>
	{
		[Inject]
		protected BulletConfig Config { get; }

		public BulletState(BulletStateType state, BulletController unit) : base(state.ToString(), unit)
		{
		}
	}
}
