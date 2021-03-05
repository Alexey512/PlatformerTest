using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrips.Common.FSM
{
	/*public class ConditionalTransition: Transition 
	{
		private readonly ICondition _condition;

		public ConditionalTransition(string stateName, ICondition condition, Action handler = null):
			base(stateName, handler)
		{
			_condition = condition;
		}

		public bool TryPerform()
		{
			if (_condition == null || !_condition.Check())
				return false;

			Handler?.Invoke();
			
			return true;
		}
	}*/
}
