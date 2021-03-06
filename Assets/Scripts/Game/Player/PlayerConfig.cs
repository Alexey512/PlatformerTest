using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scrips.Game.Player
{
	
	[CreateAssetMenu(menuName = "Game/Player config")]
	public class PlayerConfig: ScriptableObject
	{
		public float MinSpeed = 2;

		public float MoveForce = 365f;			// Amount of force added to move the player left and right.

		public float MaxSpeed = 7;

		public float Speed = 7;

		public float JumpHeight = 6.5f;

		public float Acceleration = 3;

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
