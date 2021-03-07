using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.Visual;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game.Units.Bullet
{
	public class ExplosionState: BulletState
	{
		[Inject]
		private IPrefabsFactory _factory;
		
		public ExplosionState(BulletController unit) : base(BulletStateType.Explosion, unit)
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
			_factory.Remove(Unit.gameObject, true);
		}
	}
}
