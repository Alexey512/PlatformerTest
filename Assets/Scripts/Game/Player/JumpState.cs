using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrips.Game.Player
{
	public class JumpState: PlayerState
	{
		public JumpState(PlayerController player) : base("Jump", player)
		{
		}
	}
}
