using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Track
{
	public class TrackChunk: MonoBehaviour
	{
		[SerializeField]
		private Collider2D _collider;
		
		public Rect GetRect()
		{
			if (_collider == null)
				return Rect.zero;
			return new Rect { min = _collider.bounds.min, max = _collider.bounds.max };
		}
	}
}
