using System;
using Assets.Scrips.Common.Storage;
using UnityEngine;
using Zenject;

namespace Assets.Scrips.Common.Visual
{
	public class PrefabsFactoryRef: AddressableScriptableObject<PrefabsFactory>, IPrefabsFactory
	{
		public PrefabsFactoryRef(DiContainer container) : base(container)
		{
		}

		public GameObject Create(string id, Transform parent = null)
		{
			return Data?.Create(id, parent);
		}

        public T Create<T>(string id, Transform parent = null) where T : MonoBehaviour
        {
            return Data?.Create<T>(id, parent);
        }

        public void Remove(GameObject obj, bool moveInCache = false)
		{
			Data.Remove(obj);
		}
	}
}
