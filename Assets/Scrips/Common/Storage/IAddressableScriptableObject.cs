using System;
using System.Collections;
using UnityEngine.AddressableAssets;

namespace Assets.Scrips.Common.Storage
{
	public interface IAddressableScriptableObject
	{
		float Progress { get; }

		bool IsComplete { get; }

		void Load();
	}
}
