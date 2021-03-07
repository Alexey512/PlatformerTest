using Assets.Scrips.Common.FSM;
using Assets.Scrips.Common.Visual;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scrips.Game.Scenes
{
	public class LoaderState: State
	{
		private readonly IPrefabsFactory _prefabsFactory;
		
		public LoaderState(IPrefabsFactory prefabsFactory) : base(GameStatesManager.LoaderState)
		{
			_prefabsFactory = prefabsFactory;
		}

		public override void Enter(State prevState, EventArgs args)
		{
			_prefabsFactory.Load();
		}

		public override void Update()
		{
			if (_prefabsFactory.IsComplete)
			{
				Owner.SwitchState(GameStatesManager.MainMenuState);
			}
		}
	}
}
