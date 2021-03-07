using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		private MainMenuController _mainMenu;

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

		public override void Exit(State nextState)
		{
		}

		public override void Update()
		{
			//throw new NotImplementedException();
		}
	}
}
