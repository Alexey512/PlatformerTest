using UnityEngine;

namespace Assets.Scrips.Game.Player
{
	
	[CreateAssetMenu(menuName = "Game/Player config")]
	public class PlayerConfig: ScriptableObject
	{
		public float MinSpeed = 2;

		public float MaxSpeed = 7;

		public float Speed = 7;

		public float JumpHeight = 6.5f;

		public float MaxHealth = 100f;

		public string WeaponId = string.Empty;

		public float RoF = 0.3f;
	}
}
