

namespace Assets.Scripts.Game.Units
{
	public interface IUnit
	{
		T GetModel<T>() where T: UnitModel;
	}
}
