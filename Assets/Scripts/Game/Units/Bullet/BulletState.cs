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
