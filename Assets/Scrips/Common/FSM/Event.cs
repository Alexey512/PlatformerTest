using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrips.Common.FSM
{
	public class Event
	{
		public string Id { get; set; }

		public EventArgs Args { get; set; }
	}
}
