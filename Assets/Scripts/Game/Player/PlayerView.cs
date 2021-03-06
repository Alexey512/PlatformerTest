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

		//private float _moveForce;

		private Vector2 _moveForce;

		public void SetForce(Vector2 force)
		{
			_moveForce = force;
		}

		private void UpdateMovement()
		{
			if (_body == null)
				return;

			_body.AddForce(_moveForce);
		}

		private void FixedUpdate()
		{
			UpdateMovement();
		}
	}
}
