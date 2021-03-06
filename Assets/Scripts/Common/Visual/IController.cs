using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Common.Visual
{
	public interface IController<TView> where TView: MonoBehaviour
	{
		TView View { get; set; }
	}
}
