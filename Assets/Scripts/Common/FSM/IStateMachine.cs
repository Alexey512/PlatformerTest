using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrips.Common.FSM
{
	public interface IStateMachine
	{
		void Start();

		void SetInitialState(string stateName);

		void HandleEvent(Event e);

		State AddState(State state);		
		
		State AddState<T>(IEnumerable<object> args) where T : State;

		State AddState<T>() where T : State;

		void Update();
	}
}
