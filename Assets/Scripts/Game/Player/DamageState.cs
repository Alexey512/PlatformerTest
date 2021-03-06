using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Common.FSM;
using Assets.Scrips.Game.Player;
using UnityEngine;
using EventArgs = Assets.Scrips.Common.FSM.EventArgs;

namespace Assets.Scripts.Game.Player
{
	public class DamageState: PlayerState
	{
		public DamageState(PlayerController player) : base(PlayerStateType.Damage, player)
		{
		}

		public override void Enter(State prevState, EventArgs args)
		{
			if (args != null)
			{
				float damage = args.GetValue<float>("Damage");
				Debug.Log($"Damage {damage}");
			}

			Owner.PopState();
		}
	}
}
