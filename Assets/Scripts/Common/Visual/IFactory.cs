using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrips.Common.Visual
{
	public interface IFactory
	{
		float Progress { get; }

		bool IsComplete { get; }
		
		void Load();
	}
}
