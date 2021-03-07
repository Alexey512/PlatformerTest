
namespace Assets.Scripts.Game.Units.Enemy
{
	public enum EnemyStateType
	{
		Idle,
		Move,
		Damage,
		Death,
	}

	public enum EnemyEventType
	{
		Damage
	}

	public class EnemyState: UnitState<EnemyController, EnemyModel>
	{
		public EnemyState(EnemyStateType state, EnemyController unit) : base(state.ToString(), unit)
		{
		}
	}
}
