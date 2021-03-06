using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Common.Utils
{
	public static class LayerMaskExtensions
	{
		public static bool HasLayer(this LayerMask layerMask, int layer)
		{
			if (layerMask == (layerMask | (1 << layer)))
			{
				return true;
			}
 
			return false;
		}
 
		public static bool[] HasLayers(this LayerMask layerMask)
		{
			var hasLayers = new bool[32];
 
			for (int i = 0; i < 32; i++)
			{
				if (layerMask == (layerMask | (1 << i)))
				{
					hasLayers[i] = true;
				}
			}
 
			return hasLayers;
		}
	}
}
