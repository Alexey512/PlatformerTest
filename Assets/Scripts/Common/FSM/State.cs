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

		public IStateMachine Owner { get; set; }

		public List<Transition> Transitions { get; } = new List<Transition>();

		public State(string name)
		{
			Name = name;
		}

		public void AddTransition(string targetState, string eventId, Func<EventArgs, bool> condition = null, Action<EventArgs> handler = null)
		{
			Transitions.Add(new Transition(targetState, eventId, condition, handler));
		}

		public virtual void Enter(State prevState) {}

		public virtual void Exit(State nextState) {}

		public virtual void Update() {}
	}
}
