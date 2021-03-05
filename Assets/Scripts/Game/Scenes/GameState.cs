using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.Visual;
using Assets.Scripts.Game.Scenes;

namespace Assets.Scrips.Game.Scenes
{
	public class GameState: State
	{
		private readonly IPrefabsFactory _prefabsFactory;

		private readonly VisualRoot _visualRoot;

		private GameField _field;

		public GameState(IPrefabsFactory prefabsFactory, VisualRoot visualRoot) : base("Game")
		{
			_prefabsFactory = prefabsFactory;
			_visualRoot = visualRoot;
		}

		public override void Enter(State prevState)
		{
			_field = _prefabsFactory.Create<GameField>("GameField", _visualRoot.Root);


		}

		public override void Exit(State nextState)
		{
			
		}

		public override void Update()
		{
			
		}
	}
}
