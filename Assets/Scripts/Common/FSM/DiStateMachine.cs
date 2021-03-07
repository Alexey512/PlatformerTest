using System.Collections.Generic;
using Zenject;

namespace Assets.Scrips.Common.FSM
{
	public class DiStateMachine: StateMachine, IStateMachine
	{
		private readonly DiContainer _diContainer;

		public DiStateMachine(DiContainer diContainer)
		{
			_diContainer = diContainer;
		}

		public State AddState<T>(IEnumerable<object> args) where T: State
		{
			return AddState(_diContainer.Instantiate<T>(args));
		}

		public State AddState<T>() where T: State
		{
			return AddState(_diContainer.Instantiate<T>());
		}
	}
}
