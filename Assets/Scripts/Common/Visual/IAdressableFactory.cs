using System;
using UnityEngine;

namespace Assets.Scrips.Common.Visual
{
	public interface IAdressableFactory
	{
		void LoadResource(string id, Action<GameObject> callback);

		void ReleaseResource(GameObject resource);
	}
}
