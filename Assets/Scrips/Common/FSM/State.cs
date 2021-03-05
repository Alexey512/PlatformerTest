using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrips.Common.FSM
{
	public abstract class State
	{
		public string Name { get; private set; }

		public StateMachine Owner { get; set; }

		public List<Transition> Transitions { get; } = new List<Transition>();

		//public List<EventTransition> EventTransitions { get; } = new List<EventTransition>();

		//public List<ConditionalTransition> ConditionalTransitions { get; } = new List<ConditionalTransition>();

		public State(string name)
		{
			Name = name;
		}

		public void AddTransition(string targetState, string eventId, Func<EventArgs, bool> condition = null, Action<EventArgs> handler = null)
		{
			Transitions.Add(new Transition(targetState, eventId, condition, handler));
		}

		/*
		public void AddTransition(string targetState, string eventId, Action handler = null)
		{
			EventTransitions.Add(new EventTransition(targetState, eventId, handler));
		}

		public void AddTransition(string targetState, ICondition condition, Action handler = null)
		{
			ConditionalTransitions.Add(new ConditionalTransition(targetState, condition, handler));
		}
		*/

		public abstract void Enter(State prevState);

		public abstract void Exit(State nextState);

		public abstract void Update();
	}
}
