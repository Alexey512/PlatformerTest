using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scrips.Game.Player
{
	public class PlayerView: MonoBehaviour
	{
		[SerializeField]
		private Rigidbody2D _body;

		[SerializeField]
		private Animation _animation;
	}
}
