using System;

namespace Assets.Scrips.Common.Actions
{
	public interface IActionsSequencer
	{
		void Execute(IAction action, Action<IAction> callback = null);
		
		void Remove(IAction action);
	}
}
