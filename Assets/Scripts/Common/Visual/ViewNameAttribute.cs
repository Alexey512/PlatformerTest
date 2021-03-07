using System;

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
