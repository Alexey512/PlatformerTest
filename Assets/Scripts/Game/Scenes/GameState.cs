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
using Zenject;

namespace Assets.Scrips.Game.Scenes
{
	public class GameState: State
	{
		[Inject]
		private readonly IPrefabsFactory _prefabsFactory;

		[Inject]
		private readonly VisualRoot _visualRoot;

		//[Inject]
		//private readonly PlayerFactory _playerFactory; 

		[Inject]
		private readonly TrackManager _trackManager;

		[Inject]
		private readonly PlayerCamera _camera;

		private PlayerController _player;

		//private GameField _field;


		public GameState(/*PlayerFactory playerFactory, IPrefabsFactory prefabsFactory,  VisualRoot visualRoot*/) : base("Game")
		{
			//_playerFactory = playerFactory;
			//_prefabsFactory = prefabsFactory;
			//_visualRoot = visualRoot;
		}

		public override void Enter(State prevState)
		{
			//_field = _prefabsFactory.Create<GameField>("GameField", _visualRoot.Root);

			//_player = _playerFactory.Create();
			_player = _prefabsFactory.Create<PlayerController>("Player", _visualRoot.Root);

			_player.Owner.Position = _trackManager.GetSpawnPosition();

			_camera.SetPlayer(_player);

			_trackManager.SetCamera(_camera.Camera);
			_trackManager.IsActive = true;
		}

		public override void Exit(State nextState)
		{
			
		}

		public override void Update()
		{
			if (_player != null)
			{
				_player.Update();
			}
		}
	}
}
