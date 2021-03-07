using System;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.Visual;
using Assets.Scrips.Game.Player;
using Assets.Scripts.Game.Player;
using Assets.Scripts.Game.Track;
using Assets.Scripts.Game.Units.Enemy;
using UnityEngine;
using Zenject;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;
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

		private PlayerController _player;

		public GameState() : base(GameStatesManager.GameState)
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
			_player = _prefabsFactory.Create<PlayerController>("Player", _visualRoot.Root);
			if (_player == null)
			{
				return;
			}

			_player.Death += OnPlayerDeath;

			_player.Owner.Position = _trackManager.GetSpawnPosition();

			_player.ResetParams();

			_camera.SetPlayer(_player);

			_trackManager.SetCamera(_camera.Camera);
			_trackManager.IsActive = true;

			_player.StartMove();
		}
		
		public override void Exit(State nextState)
		{
			if (_player)
			{
				_player.Death -= OnPlayerDeath;

				_prefabsFactory.Remove(_player.gameObject, true);
				_player = null;
			}

			_enemySpawner.Clear();

			_trackManager.IsActive = false;
			_trackManager.Clear();
		}

		public override void Update()
		{
			_enemySpawner.Update();
		}

		private void OnPlayerDeath()
		{
			_prefabsFactory.Remove(_player.gameObject, true);
			
			Owner.PopState();
		}
	}
}
