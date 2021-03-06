using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Common.Visual
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ViewNameAttribute: Attribute
	{
		public string Name { get; set; }

		public ViewNameAttribute(string name)
		{
			Name = name;
		}
	}
}
