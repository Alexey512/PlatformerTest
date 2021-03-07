using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.Visual;
using Assets.Scripts.Game.Track;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Game.Units.Enemy
{
	public class EnemySpawner: MonoBehaviour
	{
		private IPrefabsFactory _factory;

		private VisualRoot _visualRoot; 

		[SerializeField]
		private List<string> _prefabsIds;

		private TrackManager _trackManager;

		[Inject]
		private void Construct(IPrefabsFactory factory, VisualRoot visualRoot, TrackManager trackManager)
		{
			_visualRoot = visualRoot;
			_factory = factory;
			_trackManager = trackManager;
		}

		public EnemyController SpawnEnemy()
		{
			if (_factory == null || _prefabsIds.Count == 0)
			{
				return null;
			}

			var enemy = _factory.Create<EnemyController>(_prefabsIds[Random.Range(0, _prefabsIds.Count)], _visualRoot.Root);
			if (enemy != null)
			{
				enemy.transform.position = _trackManager.GetEnemySpawnPosition();
			}

			return enemy;
		}
	}
}
