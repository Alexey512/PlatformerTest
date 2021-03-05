﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scrips.Game.Player
{
	public class PlayerConfig: ScriptableObject
	{
		/// <summary>
		/// Max horizontal speed of the player.
		/// </summary>
		public float MaxSpeed = 7;
		/// <summary>
		/// Initial jump velocity at the start of a jump.
		/// </summary>
		public float JumpTakeOffSpeed = 7;		
		
		/// <summary>
		/// A global jump modifier applied to all initial jump velocities.
		/// </summary>
		public float JumpModifier = 1.5f;

		/// <summary>
		/// A global jump modifier applied to slow down an active jump when 
		/// the user releases the jump input.
		/// </summary>
		public float JumpDeceleration = 0.5f;


	}
}
