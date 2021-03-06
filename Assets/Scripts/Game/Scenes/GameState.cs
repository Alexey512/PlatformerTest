using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.Visual;
using Assets.Scrips.Game.Player;
using Assets.Scripts.Game.Player;
using Assets.Scripts.Game.Scenes;
using Assets.Scripts.Game.Track;
using Assets.Scripts.Game.Units.Enemy;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Assets.Scrips.Game.Scenes
{
	public class GameState: State
	{
		[Inject]
		private readonly IPrefabsFactory _prefabsFactory;

		[Inject]
		private readonly VisualRoot _visualRoot;

		[Inject]
		private readonly TrackManager _trackManager;

		[Inject]
		private readonly PlayerCamera _camera;

		[Inject]
		private readonly EnemySpawner _enemySpawner;

		[Inject]
		private readonly EnemyConfig _enemyConfig;

		private PlayerController _player;

		private float _timeToSpawn;

		public GameState() : base("Game")
		{
		}

		public override void Enter(State prevState)
		{
			_player = _prefabsFactory.Create<PlayerController>("Player", _visualRoot.Root);

			_player.Owner.Position = _trackManager.GetSpawnPosition();

			_camera.SetPlayer(_player);

			_trackManager.SetCamera(_camera.Camera);
			_trackManager.IsActive = true;

			_player.StartMove();
		}

		public override void Exit(State nextState)
		{
			
		}

		public override void Update()
		{
			if (_timeToSpawn > 0)
			{
				_timeToSpawn -= Time.deltaTime;
			}
			else
			{
				_timeToSpawn = Random.Range(_enemyConfig.MinSpawnInterval, _enemyConfig.MaxSpawnInterval);

				var enemy = _enemySpawner.SpawnEnemy();
				if (enemy)
				{
					enemy.StartMove();
				}
			}
		}
	}
}
