using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Assets.Scripts.Game.Track
{
	[ExecuteInEditMode]
	public class TrackManager: MonoBehaviour
	{
		public Vector3 GetSpawnPosition()
		{
			return _spawnMarker != null ? _spawnMarker.transform.position : Vector3.zero;
		}

		public void SetCamera(Camera camera)
		{
			_camera = camera;
		}

		public bool IsActive
		{
			get => _active;
			set
			{
				_active = value;
				UpdateChunks();
			}
		}

		[SerializeField]
		private Transform _spawnMarker;

		[SerializeField]
		private TrackChunk _chunkPref;

		[SerializeField]
		private bool _active;

		private Camera _camera;

		private readonly List<TrackChunk> _chunks = new List<TrackChunk>();

		private readonly Queue<TrackChunk> _chunksPool = new Queue<TrackChunk>();

		private TrackChunk AssignChunk()
		{
			if (_chunkPref == null)
			{
				return null;
			}

			TrackChunk chunk = null;
			if (_chunksPool.Count > 0)
			{
				chunk = _chunksPool.Dequeue();
				chunk.gameObject.SetActive(true);
			}
			else
			{
				var chunkObj = GameObject.Instantiate(_chunkPref.gameObject, transform);
				chunkObj.SetActive(true);
				chunk = chunkObj.GetComponent<TrackChunk>();
			}

			var chunkSize = chunk.GetRect().size.x;
			if (chunkSize < float.Epsilon)
			{
				chunk.gameObject.SetActive(false);
				return null;
			}

			return chunk;
		}

		private void ReleaseChunk(TrackChunk chunk)
		{
			chunk.gameObject.SetActive(false);
			_chunksPool.Enqueue(chunk);
		}

		private void Update()
		{
			UpdateChunks();
		}

		private void UpdateChunks()
		{
			if (!_camera || !_active)
			{
				return;
			}

			if (!CreateChunks())
			{
				return;
			}

			float halfHeight = _camera.orthographicSize;
			float halfWidth = _camera.aspect * halfHeight;

			float height = halfHeight * 2;
			float width = halfWidth * 2;

			Vector2 camPos = _camera.transform.position;

			float camLeft = camPos.x - halfWidth;
			float camRight = camPos.x + halfWidth;

			bool hasChunks;
			Rect chunksRect = UpdateVisibleChunks(camLeft, camRight, out hasChunks);

			float chunksLeft = chunksRect.xMin;
			float chunksRight = chunksRect.xMax;

			while (camRight > chunksRight)
			{
				var chunk = AssignChunk();
				if (chunk == null)
					break;
				var chunkSize = chunk.GetRect().size.x;
				chunk.transform.position = new Vector2(chunksRight, 0);
				chunksRight += chunkSize;
			}

			while (camLeft < chunksLeft)
			{
				var chunk = AssignChunk();
				if (chunk == null)
					break;
				var chunkSize = chunk.GetRect().size.x;
				chunk.transform.position = new Vector2(chunksLeft - chunkSize, 0);
				chunksLeft -= chunkSize;
			}
		}

		private bool CreateChunks()
		{
			float halfHeight = _camera.orthographicSize;
			float halfWidth = _camera.aspect * halfHeight;

			float height = halfHeight * 2;
			float width = halfWidth * 2;

			Vector2 camPos = _camera.transform.position;

			float camLeft = camPos.x - halfWidth;
			float camRight = camPos.x + halfWidth;			
			
			bool hasChunks;
			Rect chunksRect = UpdateVisibleChunks(camLeft, camRight, out hasChunks);

			if (!hasChunks)
			{
				var chunk = AssignChunk();
				if (chunk == null)
					return false;

				float chunkPos = camLeft - chunk.GetRect().size.x;
				chunk.transform.position = new Vector2(chunkPos, 0);

				chunksRect = UpdateVisibleChunks(camLeft, camRight, out hasChunks);
			}

			return hasChunks;
		}

		private Rect UpdateVisibleChunks(float camLeft, float camRight, out bool hasChunks)
		{
			hasChunks = false;
			Rect rect = new Rect { min = new Vector2(float.MaxValue, float.MaxValue), max = new Vector2(float.MinValue, float.MinValue)};

			for (int i = 0; i < transform.childCount; i++)
			//for (int i = transform.childCount - 1; i >= 0; i--)
			{
				var chunk = transform.GetChild(i).GetComponent<TrackChunk>();
				if (chunk == null || !chunk.gameObject.activeSelf)
				{
					continue;
				}
				
				var chunkRect = chunk.GetRect();

				if ((chunkRect.xMin < camLeft && chunkRect.xMax < camLeft) ||
				    (chunkRect.xMin > camRight && chunkRect.xMax > camRight))
				{
					ReleaseChunk(chunk);
					continue;
				}

				rect.min = new Vector2(Mathf.Min(rect.min.x, chunkRect.min.x), Mathf.Min(rect.min.y, chunkRect.min.y));
				rect.max = new Vector2(Mathf.Max(rect.max.x, chunkRect.max.x), Mathf.Min(rect.max.y, chunkRect.max.y));

				hasChunks = true;
			}

			return rect;
		}

		private void OnDrawGizmos()
		{
			if (_camera == null)
			{
				return;
			}

			float halfHeight = _camera.orthographicSize;
			float halfWidth = _camera.aspect * halfHeight;

			float height = halfHeight * 2;
			float width = halfWidth * 2;

			Vector2 camPos = _camera.transform.position;

			float camLeft = camPos.x - halfWidth;
			float camRight = camPos.x + halfWidth;





			Gizmos.color = Color.green;
			Gizmos.DrawLine(_camera.rect.min, _camera.rect.max);
		}
	}
}
