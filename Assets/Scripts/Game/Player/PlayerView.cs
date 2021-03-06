using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;

namespace Assets.Scrips.Game.Player
{
	public class PlayerView: MonoBehaviour
	{
		public float maxSpeed = 3.4f;
		public float jumpHeight = 6.5f;
		public float gravityScale = 1.5f;

		bool facingRight = true;
		float moveDirection = 0;
		
		[SerializeField]
		private Rigidbody2D _body;

		[SerializeField]
		private Collider2D _collider;

		[SerializeField]
		private Animation _animation;

		//private float _moveForce;

		private Vector2 _moveForce;

		private bool _isGrounded = false;

		private void Start()
		{
			_body.freezeRotation = true;
			_body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
			_body.gravityScale = gravityScale;
		}

		public void SetForce(Vector2 force)
		{
			_moveForce = force;
		}

		public Vector2 Velocity
		{
			get => _body != null ? _body.velocity : Vector2.zero;
			set
			{
				if (_body != null)
				{
					_body.velocity = value;
				}
			}
		}

		private void UpdateMovement()
		{
			if (_body == null)
				return;

			_body.AddForce(_moveForce);
		}

		private void FixedUpdate_()
		{
			UpdateMovement();
		}

		void Update()
		{
			// Movement controls
			if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (_isGrounded || Mathf.Abs(_body.velocity.x) > 0.01f))
			{
				moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
			}
			else
			{
				if (_isGrounded || _body.velocity.magnitude < 0.01f)
				{
					moveDirection = 0;
				}
			}

			//moveDirection = 1;

			// Jumping
			if (Input.GetKeyDown(KeyCode.W) && _isGrounded)
			{
				_body.velocity = new Vector2(_body.velocity.x, jumpHeight);
			}
		}

		private void FixedUpdate()
		{
			Bounds colliderBounds = _collider.bounds;
			float colliderRadius = colliderBounds.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
			Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
			// Check if player is grounded
			Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
			//Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
			_isGrounded = false;
			if (colliders.Length > 0)
			{
				for (int i = 0; i < colliders.Length; i++)
				{
					if (colliders[i] != _collider)
					{
						_isGrounded = true;
						break;
					}
				}
			}

			// Apply movement velocity
			_body.velocity = new Vector2((moveDirection) * maxSpeed, _body.velocity.y);

			// Simple debug
			Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), _isGrounded ? Color.green : Color.red);
			Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), _isGrounded ? Color.green : Color.red);
		}
	}
}
