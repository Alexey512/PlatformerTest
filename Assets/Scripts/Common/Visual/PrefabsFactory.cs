using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using OneLine;
using Zenject;

namespace Assets.Scrips.Common.Visual
{
	[CreateAssetMenu(fileName = "CustomPrefabsAsset", menuName = "Game/CustomPrefabsAsset", order = 1)]
	public class PrefabsFactory: ScriptableObject, IPrefabsFactory
	{
		[Serializable]
		public class PrefabItem
		{
			public string Id;

			public GameObject Prefab;
		}

		[SerializeField, OneLine, HideLabel]
		private List<PrefabItem> _Prefabs;

		private readonly Dictionary<string, Queue<GameObject>> _cache = new Dictionary<string, Queue<GameObject>>();

        [Inject]
		private DiContainer _container;

		public float Progress => 1.0f;

		public bool IsComplete => true;

		public void Load() { }

		public GameObject Create(string id, Transform parent = null)
		{
			if (_cache.TryGetValue(id, out Queue<GameObject> objects))
			{
				if (objects.Count > 0)
				{
					var obj = objects.Dequeue(); 
					obj.SetActive(true);
					obj.transform.parent = parent;
					return obj;
				}
			}

			var item = _Prefabs.Find(e => e.Id == id);
			if (item == null)
				return null;

			GameObject instance = _container.InstantiatePrefab(item.Prefab, parent);
			instance.name = id;
			return instance;
		}

        public T Create<T>(string id, Transform parent = null) where T : MonoBehaviour
        {
            return Create(id, parent)?.GetComponent<T>();
        }

        public void Remove(GameObject obj, bool moveInCache = false)
		{
			if (obj == null)
				return;

			if (moveInCache)
			{
				obj.transform.parent = null;
				obj.SetActive(false);
				Queue<GameObject> cache;
				if (!_cache.TryGetValue(obj.name, out cache))
				{
					cache = new Queue<GameObject>();
					_cache[obj.name] = cache;
				}
				cache.Enqueue(obj);
			}
			else
			{
				GameObject.Destroy(obj);
			}
		}
	}
}
