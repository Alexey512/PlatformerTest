using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.Visual;

namespace Assets.Scrips.Game.Scenes
{
	public class LoaderState: State
	{
		private readonly IPrefabsFactory _prefabsFactory;
		
		public LoaderState(IPrefabsFactory prefabsFactory) : base("Loader")
		{
			_prefabsFactory = prefabsFactory;
		}

		public override void Enter(State prevState)
		{
			_prefabsFactory.Load();
		}

		public override void Exit(State nextState)
		{
		}

		public override void Update()
		{
			if (_prefabsFactory.IsComplete)
			{
				Owner.SwitchState("Game");
			}
		}
	}
}
