using System;
using System.Collections.Generic;

namespace Assets.Scrips.Common.FSM
{
	public class EventArgs
	{
		private readonly Dictionary<string, object> _data = new Dictionary<string, object>();

		public void SetValue<T>(string id, T value)
		{
			_data[id] = value;
		}
		
		public T GetValue<T>(string id)
		{
			if (!_data.TryGetValue(id, out object value))
			{
				return default(T);
			}

			try
			{
				return (T) value;
			}
			catch (Exception)
			{
				return default(T);
			}
		}
	}
}
