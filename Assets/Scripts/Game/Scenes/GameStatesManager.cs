using Assets.Scrips.Common.FSM;
using Zenject;

namespace Assets.Scrips.Game.Scenes
{
	public class GameStatesManager: ITickable
	{
		private readonly IStateMachine _fsm;
		
		public GameStatesManager(StateMachineFactory sfm)
		{
			_fsm = sfm.Create();

			InitializeStates();
		}

		public void Start()
		{
			_fsm.Start();
		}

		private void InitializeStates()
		{
			_fsm.AddState<LoaderState>();
			_fsm.AddState<GameState>();
			_fsm.AddState<MainMenuState>();

			_fsm.SetInitialState("Loader");
		}

		public void Tick()
		{
			_fsm.Update();
		}
	}
}
