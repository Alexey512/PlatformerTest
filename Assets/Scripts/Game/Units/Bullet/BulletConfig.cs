using UnityEngine;

namespace Assets.Scripts.Game.Units.Bullet
{
	[CreateAssetMenu(menuName = "Game/Bullet config")]
	public class BulletConfig: ScriptableObject
	{
		public float Speed = 5.0f;

		public float Damage = 10.0f;
	}
}
