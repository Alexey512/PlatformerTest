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
		private State _currentState;
		
		private State _initialState;

		//TODO: States Stack

		private readonly Dictionary<string, State> _states = new Dictionary<string, State>();

		private readonly Queue<Event> _eventsQueue = new Queue<Event>();

		public StateMachine()
		{

		}

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

		/*public void AddEventTransition(string stateName, EventTransition transition)
		{
			if (!_states.TryGetValue(stateName, out State state))
			{
				Debug.LogAssertion($"State '{state.Name}' not found");
				return;
			}

			state.EventTransitions.Add(transition);
		}

		public void AddConditionalTransition(string stateName, ConditionalTransition transition)
		{
			if (!_states.TryGetValue(stateName, out State state))
			{
				Debug.LogAssertion($"State '{state.Name}' not found");
				return;
			}

			state.ConditionalTransitions.Add(transition);
		}*/

		public void SwitchState(string name)
		{
			var nextState = GetState(name);
			if (nextState == null)
			{
				return;
			};

			EnterState(nextState);
		}

		public void Update()
		{
			if (_currentState == null)
				return;

			_currentState.Update();

			if (_eventsQueue.Count > 0)
			{
				var stateEvent = _eventsQueue.Dequeue();
				
				foreach (var transition in _currentState.Transitions)
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

		/*private bool TryPerformEvent()
		{
			var stateEvent = _eventsQueue.Dequeue();
			if (stateEvent != null)
			{
				foreach (var transition in _currentState.EventTransitions)
				{
					if (transition.TryPerform(stateEvent.Id))
					{
						EnterState(transition.TargetState);
						return true;
					}
				}
			}

			return false;
		}

		private bool TryPerformCondition()
		{
			foreach (var transition in _currentState.ConditionalTransitions)
			{
				if (transition.TryPerform())
				{
					EnterState(transition.TargetState);
					return true;
				}
			}

			return false;
		}*/

		private void EnterState(State state)
		{
			if (state == null)
				return;
			
			var prevState = _currentState;
			_currentState?.Exit(state);

			_currentState = state;
			_currentState.Enter(prevState);
		}
	}
}
