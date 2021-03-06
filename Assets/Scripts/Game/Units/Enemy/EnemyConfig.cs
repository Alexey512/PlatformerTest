﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Units.Enemy
{
	[CreateAssetMenu(menuName = "Game/Enemy config")]
	public class EnemyConfig: ScriptableObject
	{
		public float MinSpeed = 1;

		public float MaxSpeed = 3;

		public float MinHealth = 30f;

		public float MaxHealth = 70f;

		public float MinSpawnInterval = 3.0f;

		public float MaxSpawnInterval = 7.0f;
	}
}