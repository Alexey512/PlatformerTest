using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scripts.Game.Units.Bullet
{
	public class FlyState: BulletState
	{
		public FlyState(BulletController unit) : base(BulletStateType.Fly, unit)
		{
		}

		public override void Enter(State prevState, EventArgs args = null)
		{
			var velocity = Unit.Owner.Velocity;
			velocity.x = Config.Speed;
			Unit.Owner.Velocity = velocity;
		}
	}
}
