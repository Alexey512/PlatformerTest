using UnityEngine;

namespace Assets.Scripts.Common.Visual
{
	public interface IController<TView> where TView: MonoBehaviour
	{
		TView View { get; set; }
	}
}
