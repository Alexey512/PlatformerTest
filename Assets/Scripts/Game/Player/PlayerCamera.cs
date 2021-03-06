using Assets.Scrips.Game.Player;
using UnityEngine;

namespace Assets.Scripts.Game.Player
{
	public class PlayerCamera: MonoBehaviour
	{
		public Vector2 Position
		{
			get => transform.position;
			set => transform.position = value;
		}

		public Camera Camera => _camera;

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private Vector2 _offset;

		private PlayerController _player;

		public void SetPlayer(PlayerController player)
		{
			_player = player;
			UpdatePositition();
		}

		private void UpdatePositition()
		{
			if (_camera == null || _player == null)
			{
				return;
			}

			var followPos = _player.Owner.Position + _offset;
			_camera.transform.position = new Vector3(followPos.x, followPos.y, _camera.transform.position.z);
		}

		private void Update()
		{
			UpdatePositition();
		}
	}
}
