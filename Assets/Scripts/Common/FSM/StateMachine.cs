using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scrips.Common.FSM
{
	public class StateMachine: IStateMachine
	{
		public event Action<State, State> ChangeState;
		
		private State _initialState;

		private readonly Stack<State> _statesStack = new Stack<State>();

		private readonly Dictionary<string, State> _states = new Dictionary<string, State>();

		private readonly Queue<Event> _eventsQueue = new Queue<Event>();

		private readonly List<Transition> _anyTransitions = new List<Transition>();

		public void Start()
		{
			if (_initialState != null)
			{
				EnterState(_initialState);
			}
		}

		public void SetInitialState(string stateName)
		{
			_initialState = GetState(stateName);
		}

		public void SetInitialState<T>(T value) where T: struct
		{
			SetInitialState(value.ToString());
		}

		public void HandleEvent(string eventId, EventArgs args = null)
		{
			_eventsQueue.Enqueue(new Event { Id = eventId, Args = args});
		}

		public void HandleEvent<T>(T value, EventArgs args = null) where T : struct
		{
			HandleEvent(value.ToString(), args);
		}

		public void HandleEvent(Event e)
		{
			_eventsQueue.Enqueue(e);
		}

		public State AddState(State state)
		{
			if (state == null)
				return null;
			if (_states.TryGetValue(state.Name, out State currState))
			{
				Debug.LogAssertion($"State '{state.Name}' already exist");
				return currState;
			}

			state.Owner = this;
			_states[state.Name] = state;
			return state;
		}

		public State AddState<T>(IEnumerable<object> args) where T : State
		{
			throw new NotImplementedException();
		}

		public State AddState<T>() where T : State
		{
			throw new NotImplementedException();
		}

		public void SwitchState<T>(T value) where T: struct
		{
			SwitchState(value.ToString());
		}

		public void SwitchState(string name)
		{
			var nextState = GetState(name);
			if (nextState == null)
			{
				return;
			};

			EnterState(nextState);
		}

		public void PopState()
		{
			if (_statesStack.Count < 2)
			{
				return;
			}

			var currState = _statesStack.Pop();
			var nextState = _statesStack.Peek();
			
			currState.Exit(nextState);
			nextState.Enter(currState);
		}

		public void AddTransition(string targetState, string eventId, Func<EventArgs, bool> condition = null, Action<EventArgs> handler = null)
		{
			_anyTransitions.Add(new Transition(targetState, eventId, condition, handler));
		}

		public void AddTransition<T, U>(T targetState, U eventType, Func<EventArgs, bool> condition = null, Action<EventArgs> handler = null) where T : struct where U : struct
		{
			AddTransition(targetState.ToString(), eventType.ToString(), condition, handler);
		}

		public void Update()
		{
			if (_statesStack.Count == 0)
			{
				return;
			}

			var currentState = _statesStack.Peek();
			if (currentState == null)
			{
				return;
			}

			currentState.Update();

			if (_eventsQueue.Count > 0)
			{
				var stateEvent = _eventsQueue.Dequeue();

				if (!CheckTransitions(stateEvent, currentState.Transitions))
				{
					CheckTransitions(stateEvent, _anyTransitions);
				}
			}
		}

		private bool CheckTransitions(Event stateEvent, List<Transition> transitions)
		{
			foreach (var transition in transitions)
			{
				if (transition.Check(stateEvent))
				{
					var nextState = GetState(transition.StateName);
					if (nextState == null)
					{
						break;
					}			

					transition.Handle(stateEvent.Args);

					EnterState(nextState, stateEvent.Args);

					return true;
				}
			}

			return false;
		}

		private State GetState(string name)
		{
			if (!_states.TryGetValue(name, out State state))
			{
				Debug.LogAssertion($"State '{name}' not found");
				return null;
			}

			return state;
		}

		private void EnterState(State nextState, EventArgs args = null)
		{
			if (nextState == null)
				return;

			State currState = null;
			if (_statesStack.Count > 0)
			{
				currState = _statesStack.Peek();
				currState.Exit(nextState);
			}

			_statesStack.Push(nextState);
			nextState.Enter(currState, args);

			ChangeState?.Invoke(nextState, currState);
		}
	}
}
