using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Game.Track
{
	public class TrackChunk: MonoBehaviour
	{
		[SerializeField]
		private Collider2D _collider;

		[SerializeField]
		private SpriteRenderer _back;

		private void Start()
		{
			if (_back)
			{
				_back.color = Random.ColorHSV();
			}
		}

		public Rect GetRect()
		{
			if (_collider == null)
				return Rect.zero;
			return new Rect { min = _collider.bounds.min, max = _collider.bounds.max };
		}
	}
}
