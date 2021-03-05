using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrips.Common.FSM
{
	public class EventArgs
	{
		public T GetValue<T>(string id)
		{
			return default(T);
		}
	}
}
