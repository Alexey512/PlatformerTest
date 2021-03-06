using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Game.Units.Bullet
{
	public class BulletController: UnitController<BulletModel>
	{
		[Inject]
		private BulletConfig _config;
		
		protected override void OnInitialize()
		{
			Model.Damage = _config.Damage;
			
			Owner.UnitCollision += UnitCollision;

			StateMachine.AddState<FlyState>(new []{ this });
			StateMachine.AddState<ExplosionState>(new []{ this });

			StateMachine.AddTransition(BulletStateType.Explosion, BulletEventType.Explosion);

			StateMachine.SetInitialState(BulletStateType.Fly);
		}

		private void UnitCollision(IUnit unit)
		{
			StateMachine.HandleEvent(BulletEventType.Explosion);
		}
	}
}
