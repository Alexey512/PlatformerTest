using System;

namespace Assets.Scrips.Common.Utils
{
	public static class AttributeExtensions
	{
		public static T GetAttribute<T>(this Type type) where T : Attribute
		{
			object[] attributes = type.GetCustomAttributes(true);

			foreach (object attribute in attributes)
				if (attribute is T targetAttribute)
					return targetAttribute;

			return null;
		}
	}
}
