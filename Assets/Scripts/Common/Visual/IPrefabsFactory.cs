using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scrips.Common.Visual
{
	public interface IPrefabsFactory: IFactory
	{
		GameObject Create(string id, Transform parent = null);
	
        T Create<T>(string id, Transform parent = null) where T: MonoBehaviour;

		void Remove(GameObject obj, bool moveInCache = false);
	}
}
