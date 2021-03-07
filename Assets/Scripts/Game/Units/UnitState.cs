using System;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.InputSystem;
using Zenject;

namespace Assets.Scripts.Game.Units
{
	public class UnitState<TController, TModel>: State where TController: UnitController<TModel> where TModel: UnitModel, new()
	{
		protected TController Unit { get; }
		
		[Inject]
		protected IInputManager InputManager { get; }

		public UnitState(string name, TController unit) : base(name)
		{
			Unit = unit;
		}
	}
}
