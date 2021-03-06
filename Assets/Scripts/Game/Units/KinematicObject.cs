using System;
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
		public float Speed = 1.0f;
		
		[SerializeField]
		public float JumpHeight = 6.5f;

		[SerializeField]
		private Rigidbody2D _body;

		[SerializeField]
		private LayerMask _groundMask;

		[SerializeField]
		private Collider2D _collider;

		public float gravityScale = 1.5f;

		public float moveDirection = 0;

		private Vector2 _moveForce;

		//private bool _isGrounded = false;

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

		private Vector2 _velocity;

		public void Jump()
		{
			if (_body && IsGrounded)
			{
				_body.velocity = new Vector2(_body.velocity.x, JumpHeight);
			}
		}

		private void Start()
		{
			if (_body)
			{
				_body.freezeRotation = true;
				_body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
				_body.gravityScale = gravityScale;
			}
		}

		private void Update()
		{
			// Movement controls
			if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (IsGrounded || Mathf.Abs(_body.velocity.x) > 0.01f))
			{
				moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
			}
			else
			{
				if (IsGrounded || _body.velocity.magnitude < 0.01f)
				{
					moveDirection = 0;
				}
			}

			//moveDirection = 1;

			// Jumping
			if (Input.GetKeyDown(KeyCode.W) && IsGrounded)
			{
				_body.velocity = new Vector2(_body.velocity.x, JumpHeight);
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

			//_body.velocity = new Vector2((moveDirection) * Speed, _body.velocity.y);

			_body.velocity = _velocity;

			Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), IsGrounded ? Color.green : Color.red);
			Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), IsGrounded ? Color.green : Color.red);
		}
	}
}
