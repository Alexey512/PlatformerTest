using Assets.Scrips.Common.FSM;
using Assets.Scrips.Game.UI;
using Assets.Scripts.Common.UI;
using Zenject;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scrips.Game.Scenes
{
	public class MainMenuState: State
	{
		[Inject]
		private IUIManager _uiManager;

		public MainMenuState() : base("MainMenu")
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
			var mainMenu = _uiManager.Open<MainMenuController>();
			mainMenu.SetCallback(() =>
			{
				mainMenu.Close();
				Owner.SwitchState("Game");
			});
		}
	}
}
