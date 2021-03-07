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

		[Inject]
		private VisualRoot _visualRoot; 

		public ShootState(PlayerController player) : base(PlayerStateType.Shoot, player)
		{
		}

		public override void Enter(State prevState, EventArgs args = null)
		{
			var bullet = _factory.Create<BulletController>(Config.WeaponId, _visualRoot.Root);
			if (bullet != null)
			{
				bullet.StartMove();
				bullet.transform.position = Unit.transform.position;
			}

			Owner.PopState();
		}
	}
}
