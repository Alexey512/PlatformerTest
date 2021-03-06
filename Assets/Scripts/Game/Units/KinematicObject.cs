﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Units
{
	public class KinematicObject: MonoBehaviour
	{
		[SerializeField]
		private Rigidbody2D _body;

		[SerializeField]
		private LayerMask _groundMask;

		[SerializeField]
		private Collider2D _collider;

		[SerializeField]
		private float _gravityScale = 1.5f;

		private Vector2 _velocity;

		public bool IsGrounded { get; private set; }

		public Vector2 Position
		{
			get => transform.position;
			set => transform.position = new Vector3(value.x, value.y, transform.position.z);
		}

		public Vector2 Velocity
		{
			get => _body != null ? _body.velocity : Vector2.zero;
			set => _velocity = value;
		}

		private void Start()
		{
			if (_body)
			{
				_body.freezeRotation = true;
				_body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
				_body.gravityScale = _gravityScale;
			}
		}

		private void FixedUpdate()
		{
			if (_body == null)
			{
				return;
			}
			
			Bounds colliderBounds = _collider.bounds;
			float colliderRadius = colliderBounds.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
			Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
			Collider2D[] intersectColliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
			
			IsGrounded = false;
			if (intersectColliders.Length > 0)
			{
				foreach (var intersect in intersectColliders)
				{
					if (intersect != _collider)
					{
						IsGrounded = true;
						break;
					}
				}
			}

			_body.velocity = _velocity;

			Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), IsGrounded ? Color.green : Color.red);
			Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), IsGrounded ? Color.green : Color.red);
		}
	}
}