using System;
using UnityEngine;

namespace Assets.Scrips.Common.Visual
{
	public interface IAdressableSpritesFactory
	{
		void LoadResource(string id, Action<Sprite> callback);

		void ReleaseResource(string id, Action<Sprite> callback);

	}
}
