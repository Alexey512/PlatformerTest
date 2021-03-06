using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.InputSystem;
using Assets.Scrips.Game.Player;
using Zenject;

namespace Assets.Scripts.Game.Units
{
	public class UnitState<TController>: State where TController: UnitController
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
