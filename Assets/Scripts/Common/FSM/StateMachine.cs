using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scrips.Common.FSM
{
	public class StateMachine
	{
		private State _initialState;

		private readonly Stack<State> _statesStack = new Stack<State>();

		//TODO: States Stack

		private readonly Dictionary<string, State> _states = new Dictionary<string, State>();

		private readonly Queue<Event> _eventsQueue = new Queue<Event>();

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
				
				foreach (var transition in currentState.Transitions)
				{
					if (transition.Check(stateEvent))
					{
						var nextState = GetState(transition.StateName);
						if (nextState == null)
						{
							break;
						}			

						transition.Handle(stateEvent.Args);

						EnterState(nextState);
					}
				}
			}
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

		private void EnterState(State nextState)
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
			nextState.Enter(currState);
		}
	}
}
