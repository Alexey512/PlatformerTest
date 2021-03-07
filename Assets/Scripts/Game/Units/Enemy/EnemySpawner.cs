using System;
using System.Collections.Generic;
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

		private List<EnemyController> _enemies = new List<EnemyController>();

		private EnemyConfigs _config;
		
		private float _timeToSpawn;

		[Inject]
		private void Construct(IPrefabsFactory factory, VisualRoot visualRoot, TrackManager trackManager, EnemyConfigs config)
		{
			_visualRoot = visualRoot;
			_factory = factory;
			_trackManager = trackManager;
			_config = config;

			ResetTime();
		}

		public EnemyController SpawnEnemy()
		{
			if (_factory == null || _prefabsIds.Count == 0)
			{
				return null;
			}

			string enemyId = _prefabsIds[Random.Range(0, _prefabsIds.Count)];
			var enemy = _factory.Create<EnemyController>(enemyId, _visualRoot.Root);
			if (enemy != null)
			{
				enemy.transform.position = _trackManager.GetEnemySpawnPosition();
				
				enemy.SetConfig(_config.GetConfigs(enemyId));

				enemy.Death += OnEnemyDeath;

				enemy.StartMove();

				_enemies.Add(enemy);
			}

			return enemy;
		}

		public void Clear()
		{
			foreach (var enemy in _enemies)
			{
				_factory.Remove(enemy.gameObject, true);
			}
		}

		public void Update()
		{
			if (_timeToSpawn > 0)
			{
				_timeToSpawn -= Time.deltaTime;
			}
			else
			{
				ResetTime();

				SpawnEnemy();
			}
		}

		private void ResetTime()
		{
			_timeToSpawn = Random.Range(_config.MinSpawnInterval, _config.MaxSpawnInterval);
		}

		private void OnEnemyDeath(EnemyController enemy)
		{
			_enemies.Remove(enemy);
		}
	}
}
