using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrips.Common.FSM
{
	public interface ICondition
	{
		bool Check(State currState, State nextState);
	}
}
