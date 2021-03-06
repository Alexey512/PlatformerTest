using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scrips.Game.Scenes
{
	public class MainMenuState: State
	{
		public MainMenuState() : base("MainMenu")
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
			throw new NotImplementedException();
		}

		public override void Exit(State nextState)
		{
			throw new NotImplementedException();
		}

		public override void Update()
		{
			throw new NotImplementedException();
		}
	}
}
