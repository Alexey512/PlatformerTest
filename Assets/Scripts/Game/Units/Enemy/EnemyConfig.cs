using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Game.Units.Enemy
{
	[CreateAssetMenu(menuName = "Game/Enemy config")]
	public class EnemyConfigs: ScriptableObject
	{
		[Serializable]
		public class Config
		{
			public string Id;
			
			public float MinDamage = 3f;

			public float MaxDamage = 10f;

			public float MinSpeed = 1;

			public float MaxSpeed = 3;

			public float MinHealth = 30f;

			public float MaxHealth = 70f;
		}

		public float MinSpawnInterval = 3.0f;

		public float MaxSpawnInterval = 7.0f;

		[SerializeField]
		private Config _defaultConfig;

		[SerializeField]
		private List<Config> _configs;

		public Config GetConfigs(string id)
		{
			var config = _configs.FirstOrDefault(c => c.Id == id);
			return config ?? _defaultConfig;
		}
	}
}
