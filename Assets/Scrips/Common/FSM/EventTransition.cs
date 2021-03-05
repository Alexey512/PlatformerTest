using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrips.Common.FSM
{
	/*public class EventTransition: Transition
	{
		private readonly string _eventId;
		
		public EventTransition(string stateName, string eventId, Action handler = null): 
			base(stateName, handler)
		{
			_eventId = eventId;
		}

		public bool TryPerform(string eventId)
		{
			if (_eventId != eventId)
				return false;

			Handler?.Invoke();
			
			return true;
		}
	}*/
}
