using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.Units
{
	public interface IUnit
	{
		T GetModel<T>() where T: UnitModel;
	}
}
