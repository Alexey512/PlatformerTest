using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.Visual;
using Assets.Scrips.Game.Player;
using Assets.Scripts.Common.Visual;
using Zenject;

namespace Assets.Scripts.Game.Player
{
	public class PlayerFactory: ControllerFactory<PlayerView, PlayerController>
	{
		private readonly VisualRoot _root;

		public PlayerFactory(IPrefabsFactory prefabsFactory, DiContainer container, VisualRoot root) : base(prefabsFactory, container)
		{
			_root = root;
		}

		public override PlayerController Create()
		{
			var controller = base.Create();
			if (controller != null)
			{
				controller.View.transform.parent = _root.Root;
			}
			return controller;
		}
	}
}
