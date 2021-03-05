using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrips.Common.FSM
{
	public class Transition
	{
		public string StateName { get; }

		private readonly string _eventId;

		private readonly Func<EventArgs, bool> _condition;

		protected readonly Action<EventArgs> Handler = null;

		public Transition(string stateName, string eventId, Func<EventArgs, bool> condition, Action<EventArgs> handler = null)
		{
			StateName = stateName;
			_eventId = eventId;
			_condition = condition;
			Handler = handler;
		}

		public bool Check(Event e)
		{
			if (e.Id != _eventId)
				return false;

			return _condition == null || _condition(e.Args);
		}

		public void Handle(EventArgs args)
		{
			Handler?.Invoke(args);
		}
	}
}
