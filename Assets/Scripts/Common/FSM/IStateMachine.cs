using System;
using System.Collections.Generic;

namespace Assets.Scrips.Common.FSM
{
	public interface IStateMachine
	{
		event Action<State, State> ChangeState; 
		
		void Start();

		void SetInitialState(string stateName);

		void SetInitialState<T>(T value) where T : struct;

		void SwitchState(string name);

		void SwitchState<T>(T value) where T : struct;

		void PopState();

		void HandleEvent(string eventId, EventArgs args = null);

		void HandleEvent<T>(T value, EventArgs args = null) where T : struct;

		void HandleEvent(Event e);

		State AddState(State state);		
		
		State AddState<T>(IEnumerable<object> args) where T : State;

		State AddState<T>() where T : State;

		void AddTransition(string targetState, string eventId, Func<EventArgs, bool> condition = null,
			Action<EventArgs> handler = null);

		void AddTransition<T, U>(T targetState, U eventType, Func<EventArgs, bool> condition = null,
			Action<EventArgs> handler = null) where T : struct where U : struct;

		void Update();
	}
}
