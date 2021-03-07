using UnityEngine;

namespace Assets.Scrips.Common.Visual
{
	public interface IVisualFactory
	{
		Sprite GetIcon(string id);
		
		Sprite GetSprite(string id);
	}
}
