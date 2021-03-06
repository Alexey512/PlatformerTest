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

namespace Assets.Scrips.Game.Scenes
{
	public class GameState: State
	{
		private readonly IPrefabsFactory _prefabsFactory;

		private readonly VisualRoot _visualRoot;

		private PlayerFactory _playerFactory; 

		private GameField _field;

		private PlayerController _player;

		public GameState(PlayerFactory playerFactory, IPrefabsFactory prefabsFactory, VisualRoot visualRoot) : base("Game")
		{
			_playerFactory = playerFactory;
			_prefabsFactory = prefabsFactory;
			_visualRoot = visualRoot;
		}

		public override void Enter(State prevState)
		{
			_field = _prefabsFactory.Create<GameField>("GameField", _visualRoot.Root);

			_player = _playerFactory.Create();
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
