using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using UnityEngine;

namespace Assets.Scripts.Game.Units.Bullet
{
	public class ExplosionState: BulletState
	{
		public ExplosionState(BulletController unit) : base(BulletStateType.Explosion, unit)
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
			//TODO: pool
			GameObject.Destroy(Unit.gameObject);
		}
	}
}
